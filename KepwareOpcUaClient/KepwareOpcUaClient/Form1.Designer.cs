namespace KepwareOpcUaClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBrowse = new System.Windows.Forms.Label();
            this.tvOpcNodes = new System.Windows.Forms.TreeView();
            this.gbReadWrite = new System.Windows.Forms.GroupBox();
            this.gbBrowse = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblReadTag = new System.Windows.Forms.Label();
            this.txtReadTagPath = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtReadValue = new System.Windows.Forms.TextBox();
            this.lblReadValue = new System.Windows.Forms.Label();
            this.lblWriteTag = new System.Windows.Forms.Label();
            this.txtWriteTagPath = new System.Windows.Forms.TextBox();
            this.lblWriteValue = new System.Windows.Forms.Label();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.txtEndpointUrl = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbReadWrite.SuspendLayout();
            this.gbBrowse.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBrowse
            // 
            this.lblBrowse.AutoSize = true;
            this.lblBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrowse.Location = new System.Drawing.Point(6, 40);
            this.lblBrowse.Name = "lblBrowse";
            this.lblBrowse.Size = new System.Drawing.Size(162, 18);
            this.lblBrowse.TabIndex = 0;
            this.lblBrowse.Text = "OPC UA Tags / Nodes:";
            // 
            // tvOpcNodes
            // 
            this.tvOpcNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOpcNodes.Location = new System.Drawing.Point(0, 0);
            this.tvOpcNodes.Name = "tvOpcNodes";
            this.tvOpcNodes.Size = new System.Drawing.Size(358, 310);
            this.tvOpcNodes.TabIndex = 1;
            // 
            // gbReadWrite
            // 
            this.gbReadWrite.Controls.Add(this.btnWrite);
            this.gbReadWrite.Controls.Add(this.txtWriteValue);
            this.gbReadWrite.Controls.Add(this.lblWriteValue);
            this.gbReadWrite.Controls.Add(this.txtWriteTagPath);
            this.gbReadWrite.Controls.Add(this.lblWriteTag);
            this.gbReadWrite.Controls.Add(this.lblReadValue);
            this.gbReadWrite.Controls.Add(this.txtReadValue);
            this.gbReadWrite.Controls.Add(this.btnRead);
            this.gbReadWrite.Controls.Add(this.panel3);
            this.gbReadWrite.Controls.Add(this.lblReadTag);
            this.gbReadWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReadWrite.Location = new System.Drawing.Point(402, 172);
            this.gbReadWrite.Name = "gbReadWrite";
            this.gbReadWrite.Size = new System.Drawing.Size(370, 377);
            this.gbReadWrite.TabIndex = 4;
            this.gbReadWrite.TabStop = false;
            this.gbReadWrite.Text = "Read/Write Tag";
            // 
            // gbBrowse
            // 
            this.gbBrowse.Controls.Add(this.panel2);
            this.gbBrowse.Controls.Add(this.lblBrowse);
            this.gbBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBrowse.Location = new System.Drawing.Point(12, 172);
            this.gbBrowse.Name = "gbBrowse";
            this.gbBrowse.Size = new System.Drawing.Size(370, 377);
            this.gbBrowse.TabIndex = 5;
            this.gbBrowse.TabStop = false;
            this.gbBrowse.Text = "Browse Address Space";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.tvOpcNodes);
            this.panel2.Location = new System.Drawing.Point(6, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 310);
            this.panel2.TabIndex = 2;
            // 
            // lblReadTag
            // 
            this.lblReadTag.AutoSize = true;
            this.lblReadTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadTag.Location = new System.Drawing.Point(6, 40);
            this.lblReadTag.Name = "lblReadTag";
            this.lblReadTag.Size = new System.Drawing.Size(132, 18);
            this.lblReadTag.TabIndex = 0;
            this.lblReadTag.Text = "Tag Path (NodeId):";
            // 
            // txtReadTagPath
            // 
            this.txtReadTagPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReadTagPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadTagPath.Location = new System.Drawing.Point(0, 0);
            this.txtReadTagPath.Name = "txtReadTagPath";
            this.txtReadTagPath.Size = new System.Drawing.Size(358, 24);
            this.txtReadTagPath.TabIndex = 1;
            this.txtReadTagPath.Text = "ns=2;s=Channel1.Device1.MyTag";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtReadTagPath);
            this.panel3.Location = new System.Drawing.Point(6, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 24);
            this.panel3.TabIndex = 2;
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(6, 91);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(358, 27);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read Value";
            this.btnRead.UseVisualStyleBackColor = true;
            // 
            // txtReadValue
            // 
            this.txtReadValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadValue.Location = new System.Drawing.Point(6, 167);
            this.txtReadValue.Name = "txtReadValue";
            this.txtReadValue.ReadOnly = true;
            this.txtReadValue.Size = new System.Drawing.Size(358, 24);
            this.txtReadValue.TabIndex = 4;
            // 
            // lblReadValue
            // 
            this.lblReadValue.AutoSize = true;
            this.lblReadValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadValue.Location = new System.Drawing.Point(6, 146);
            this.lblReadValue.Name = "lblReadValue";
            this.lblReadValue.Size = new System.Drawing.Size(87, 18);
            this.lblReadValue.TabIndex = 5;
            this.lblReadValue.Text = "Read Value:";
            // 
            // lblWriteTag
            // 
            this.lblWriteTag.AutoSize = true;
            this.lblWriteTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWriteTag.Location = new System.Drawing.Point(6, 241);
            this.lblWriteTag.Name = "lblWriteTag";
            this.lblWriteTag.Size = new System.Drawing.Size(132, 18);
            this.lblWriteTag.TabIndex = 6;
            this.lblWriteTag.Text = "Tag Path (NodeId):";
            // 
            // txtWriteTagPath
            // 
            this.txtWriteTagPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWriteTagPath.Location = new System.Drawing.Point(6, 262);
            this.txtWriteTagPath.Name = "txtWriteTagPath";
            this.txtWriteTagPath.ReadOnly = true;
            this.txtWriteTagPath.Size = new System.Drawing.Size(358, 24);
            this.txtWriteTagPath.TabIndex = 7;
            // 
            // lblWriteValue
            // 
            this.lblWriteValue.AutoSize = true;
            this.lblWriteValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWriteValue.Location = new System.Drawing.Point(6, 289);
            this.lblWriteValue.Name = "lblWriteValue";
            this.lblWriteValue.Size = new System.Drawing.Size(104, 18);
            this.lblWriteValue.TabIndex = 8;
            this.lblWriteValue.Text = "Value to Write:";
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWriteValue.Location = new System.Drawing.Point(6, 310);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.ReadOnly = true;
            this.txtWriteValue.Size = new System.Drawing.Size(358, 24);
            this.txtWriteValue.TabIndex = 9;
            // 
            // btnWrite
            // 
            this.btnWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrite.Location = new System.Drawing.Point(6, 340);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(358, 27);
            this.btnWrite.TabIndex = 10;
            this.btnWrite.Text = "Write Value";
            this.btnWrite.UseVisualStyleBackColor = true;
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.lblStatus);
            this.gbConnection.Controls.Add(this.btnDisconnect);
            this.gbConnection.Controls.Add(this.btnConnect);
            this.gbConnection.Controls.Add(this.txtEndpointUrl);
            this.gbConnection.Controls.Add(this.lblEndpoint);
            this.gbConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConnection.Location = new System.Drawing.Point(12, 12);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(754, 154);
            this.gbConnection.TabIndex = 6;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "OPC UA Connection";
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndpoint.Location = new System.Drawing.Point(6, 40);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(131, 18);
            this.lblEndpoint.TabIndex = 0;
            this.lblEndpoint.Text = "OPC UA Endpoint:";
            // 
            // txtEndpointUrl
            // 
            this.txtEndpointUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndpointUrl.Location = new System.Drawing.Point(143, 37);
            this.txtEndpointUrl.Name = "txtEndpointUrl";
            this.txtEndpointUrl.Size = new System.Drawing.Size(605, 24);
            this.txtEndpointUrl.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(143, 67);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(164, 27);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(313, 67);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(164, 27);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(140, 109);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(149, 18);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: Disconnected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.gbBrowse);
            this.Controls.Add(this.gbReadWrite);
            this.Name = "Form1";
            this.Text = "KEPServerEX OPC UA Client";
            this.gbReadWrite.ResumeLayout(false);
            this.gbReadWrite.PerformLayout();
            this.gbBrowse.ResumeLayout(false);
            this.gbBrowse.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBrowse;
        private System.Windows.Forms.TreeView tvOpcNodes;
        private System.Windows.Forms.GroupBox gbReadWrite;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtReadTagPath;
        private System.Windows.Forms.Label lblReadTag;
        private System.Windows.Forms.GroupBox gbBrowse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Label lblWriteValue;
        private System.Windows.Forms.TextBox txtWriteTagPath;
        private System.Windows.Forms.Label lblWriteTag;
        private System.Windows.Forms.Label lblReadValue;
        private System.Windows.Forms.TextBox txtReadValue;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtEndpointUrl;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

