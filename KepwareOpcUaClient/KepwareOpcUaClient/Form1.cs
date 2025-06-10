using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KepwareOpcUaClient
{
    public partial class Form1 : Form
    {
        private ApplicationConfiguration _configuration;
        private EndpointConfiguration _endPointConfiguration;
        private Session _session;
        private EndpointDescription _selectedEndpoint;
        private double doubleVal;
        private int intVal;

        public Form1()
        {
            InitializeComponent();
            txtEndpointUrl.Text = "opc.tcp://localhost:49320"; // Default KEPServerEX OPC UA port
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeOpcUaClient();
        }

        private async Task InitializeOpcUaClient()
        {
            try
            {
                // Create an application configuration
                _configuration = new ApplicationConfiguration();
                _configuration.ApplicationName = "KepwareOpcUaClient";
                _configuration.ApplicationUri = Utils.Format(@"urn:{0}:KepwareOpcUaClient", System.Net.Dns.GetHostName());
                _configuration.ApplicationType = ApplicationType.Client;

                // Security configuration (for development, we might trust all for now, but in production, manage certificates properly)
                _configuration.SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier { StoreType = "Directory", StorePath = "certificates", SubjectName = _configuration.ApplicationName },
                    TrustedPeerCertificates = new CertificateTrustList { StoreType = "Directory", StorePath = "certificates/trusted" },
                    RejectedCertificateStore = new CertificateTrustList { StoreType = "Directory", StorePath = "certificates/rejected" },
                    AutoAcceptUntrustedCertificates = true // FOR DEVELOPMENT ONLY - DO NOT USE IN PRODUCTION
                };

                // Add Trace and Log configuration (optional but good for debugging)
                _configuration.TraceConfiguration = new TraceConfiguration
                {
                    OutputFilePath = "KepwareOpcUaClient.log",
                    DeleteOnLoad = true,
                    TraceMasks = 515 // Errors, Warnings, Info, Debug, PDU
                };

                // Validate the configuration
                await _configuration.Validate(ApplicationType.Client);

                // Create an ApplicationInstance
                ApplicationInstance application = new ApplicationInstance
                {
                    ApplicationName = _configuration.ApplicationName,
                    ApplicationType = _configuration.ApplicationType,
                    ApplicationConfiguration = _configuration
                };

                // Check for and install the application certificate.
                // This method will create a new certificate if one doesn't exist at the configured path.
                await application.CheckApplicationInstanceCertificate(false, 2048); // false for no interactive dialog, 2048 for key size

                lblStatus.Text = "Status: Client Initialized. Ready to connect.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Initialization Error - {ex.Message}";
                MessageBox.Show($"Client Initialization Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (_session != null && _session.Connected)
            {
                MessageBox.Show("Already connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                lblStatus.Text = "Status: Connecting...";
                ApplicationConfiguration config = _configuration; // Use the initialized configuration

                // Discover endpoints
                Uri uri = new Uri(txtEndpointUrl.Text);
                DiscoverServer(uri);

                if (_selectedEndpoint == null)
                {
                    lblStatus.Text = "Status: No suitable endpoint found.";
                    MessageBox.Show("No suitable OPC UA endpoint found at the specified URL.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a ConfiguredEndpoint from the EndpointDescription and ApplicationConfiguration
                ConfiguredEndpoint configuredEndpoint = new ConfiguredEndpoint(
                    null, // Use default or specific endpoint configuration if needed
                    _selectedEndpoint,
                    _endPointConfiguration);

                // Connect to the server using the ConfiguredEndpoint
                _session = await Session.Connect(
                    configuredEndpoint,
                    "KepwareOpcUaClient", // Session name
                    null, // UserIdentity (null for anonymous)
                    null, // PreferredLocales
                    60000); // Session timeout (milliseconds)

                if (_session.Connected)
                {
                    lblStatus.Text = $"Status: Connected to {_session.SessionName} ({_session.Endpoint.EndpointUrl})";
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    await BrowseNodes(ObjectIds.ObjectsFolder, tvOpcNodes.Nodes); // Browse starting from Objects folder
                }
                else
                {
                    lblStatus.Text = "Status: Connection Failed.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Connection Error - {ex.Message}";
                MessageBox.Show($"Connection Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DiscoverServer(Uri discoveryUri)
        {
            try
            {
                // Create a DiscoveryClient
                using (DiscoveryClient client = DiscoveryClient.Create(discoveryUri))
                {
                    // Get endpoints from the discovery server
                    EndpointDescriptionCollection endpoints = client.GetEndpoints(null);

                    // Filter and select the best endpoint (e.g., highest security, or first available)
                    // For simplicity, let's just take the first one that matches the security policy None
                    // In a real application, you'd present options to the user or have a more robust selection logic.
                    _selectedEndpoint = null;
                    foreach (EndpointDescription endpoint in endpoints)
                    {
                        // Prioritize unauthenticated/anonymous for simplicity in this example
                        if (endpoint.SecurityPolicyUri == SecurityPolicies.None && endpoint.SecurityMode == MessageSecurityMode.None)
                        {
                            _selectedEndpoint = endpoint;
                            break;
                        }
                        // Fallback to basic security if none is not available
                        else if (endpoint.SecurityPolicyUri == SecurityPolicies.Basic256Sha256 && endpoint.SecurityMode == MessageSecurityMode.SignAndEncrypt)
                        {
                            _selectedEndpoint = endpoint;
                            break;
                        }
                    }

                    if (_selectedEndpoint == null && endpoints.Count > 0)
                    {
                        // If no preferred endpoint found, just take the first one
                        _selectedEndpoint = endpoints[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error discovering endpoints: {ex.Message}", "Discovery Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _selectedEndpoint = null;
            }
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (_session != null && _session.Connected)
            {
                _session.Close();
                _session.Dispose();
                _session = null;
                lblStatus.Text = "Status: Disconnected.";
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                tvOpcNodes.Nodes.Clear(); // Clear browsed nodes
            }
        }

        private async Task BrowseNodes(NodeId nodeId, TreeNodeCollection treeNodeCollection)
        {
            if (_session == null || !_session.Connected) return;

            try
            {
                // Start Browse from the specified node
                ReferenceDescriptionCollection references;
                byte[] continuationPoint;

                // Make sure the parameters match the exact signature:
                // out ReferenceDescriptionCollection references, out byte[] continuationPoint
                _session.Browse(
                    null, // RequestHeader
                    null, // ViewDescription
                    nodeId, // NodeId to browse from
                    0U,   // MaxReferencesToReturn (0 for server default)
                    BrowseDirection.Forward, // BrowseDirection
                    ReferenceTypeIds.HierarchicalReferences, // ReferenceTypeId
                    true, // IncludeSubtypes
                    0,    // NodeClassMask (0 for all)
                    out continuationPoint,       // This MUST be ReferenceDescriptionCollection
                    out references); // This MUST be byte[]

                foreach (ReferenceDescription reference in references)
                {
                    TreeNode newNode = new TreeNode(reference.DisplayName.Text);
                    newNode.Tag = reference; // Store the ReferenceDescription in the Tag property

                    treeNodeCollection.Add(newNode);

                    // Recursively browse children (optional, can be expanded on node expansion)
                    // For now, let's just add a dummy node to indicate children might exist
                    if (reference.NodeClass == NodeClass.Object || reference.NodeClass == NodeClass.Variable)
                    {
                         // Add a dummy node to allow lazy loading
                        newNode.Nodes.Add("Loading...");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Browse nodes: {ex.Message}", "Browse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tvOpcNodes_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode expandingNode = e.Node;

            // Check if it's the dummy node
            if (expandingNode.Nodes.Count == 1 && expandingNode.Nodes[0].Text == "Loading...")
            {
                expandingNode.Nodes.Clear(); // Clear the dummy node

                ReferenceDescription reference = expandingNode.Tag as ReferenceDescription;
                if (reference != null)
                {
                    await BrowseNodes(reference.NodeId, expandingNode.Nodes);
                }
            }
        }

        private async void btnRead_Click(object sender, EventArgs e)
        {
            if (_session == null || !_session.Connected)
            {
                MessageBox.Show("Not connected to OPC UA server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tagPath = txtReadTagPath.Text;
                if (string.IsNullOrWhiteSpace(tagPath))
                {
                    MessageBox.Show("Please enter a Tag Path to read.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a read value ID
                ReadValueId readValueId = new ReadValueId
                {
                    NodeId = new NodeId(tagPath), // Assuming tagPath is the NodeId (e.g., "ns=2;s=Channel1.Device1.Tag1")
                    AttributeId = Attributes.Value // We want to read the value attribute
                };

                ReadValueIdCollection nodesToRead = new ReadValueIdCollection { readValueId };

                // Create a ReadRequest
                DataValueCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                _session.Read(
                    null,
                    0,
                    TimestampsToReturn.Both,
                    nodesToRead,
                    out results,
                    out diagnosticInfos);

                if (results != null && results.Count > 0)
                {
                    DataValue dataValue = results[0];
                    if (StatusCode.IsGood(dataValue.StatusCode))
                    {
                        txtReadValue.Text = dataValue.Value?.ToString();
                    }
                    else
                    {
                        txtReadValue.Text = $"Error: {dataValue.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading tag: {ex.Message}", "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReadValue.Text = "Error";
            }
        }

        private async void btnWrite_Click(object sender, EventArgs e)
        {
            if (_session == null || !_session.Connected)
            {
                MessageBox.Show("Not connected to OPC UA server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tagPath = txtWriteTagPath.Text;
                string valueToWrite = txtWriteValue.Text;

                if (string.IsNullOrWhiteSpace(tagPath) || string.IsNullOrWhiteSpace(valueToWrite))
                {
                    MessageBox.Show("Please enter both Tag Path and Value to write.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Determine the data type of the tag to write the correct variant.
                // This is a simplification. In a real app, you'd read the DataType attribute of the node first.
                // For demonstration, let's assume it's a double, int, or string based on parsing.
                object parsedValue;
                if (double.TryParse(valueToWrite, out doubleVal))
                {
                    parsedValue = doubleVal;
                }
                else if (int.TryParse(valueToWrite, out intVal))
                {
                    parsedValue = intVal;
                }
                else
                {
                    parsedValue = valueToWrite; // Assume string if not number
                }

                WriteValue writeValue = new WriteValue
                {
                    NodeId = new NodeId(tagPath),
                    AttributeId = Attributes.Value,
                    Value = new DataValue(new Variant(parsedValue))
                };

                WriteValueCollection nodesToWrite = new WriteValueCollection { writeValue };

                StatusCodeCollection results;
                DiagnosticInfoCollection diagnosticInfos;

                _session.Write(
                    null,
                    nodesToWrite,
                    out results,
                    out diagnosticInfos);

                if (results != null && results.Count > 0 && StatusCode.IsGood(results[0]))
                {
                    MessageBox.Show($"Successfully wrote '{valueToWrite}' to '{tagPath}'.", "Write Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Failed to write to '{tagPath}'. Error: {results[0]}", "Write Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing tag: {ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}