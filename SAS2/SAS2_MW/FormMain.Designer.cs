namespace SAS2_MW
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxHTTPLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLastHTTPResponse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.textBoxArduinoIn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxArduinoOut = new System.Windows.Forms.TextBox();
            this.buttonRefreshPort = new System.Windows.Forms.Button();
            this.checkBoxViewPolling = new System.Windows.Forms.CheckBox();
            this.checkBoxViewSYNACK = new System.Windows.Forms.CheckBox();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxHTTPLog
            // 
            this.textBoxHTTPLog.Location = new System.Drawing.Point(12, 96);
            this.textBoxHTTPLog.Multiline = true;
            this.textBoxHTTPLog.Name = "textBoxHTTPLog";
            this.textBoxHTTPLog.ReadOnly = true;
            this.textBoxHTTPLog.Size = new System.Drawing.Size(150, 413);
            this.textBoxHTTPLog.TabIndex = 2;
            this.textBoxHTTPLog.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "HTTP Requests";
            // 
            // textBoxLastHTTPResponse
            // 
            this.textBoxLastHTTPResponse.Location = new System.Drawing.Point(168, 96);
            this.textBoxLastHTTPResponse.Multiline = true;
            this.textBoxLastHTTPResponse.Name = "textBoxLastHTTPResponse";
            this.textBoxLastHTTPResponse.ReadOnly = true;
            this.textBoxLastHTTPResponse.Size = new System.Drawing.Size(150, 413);
            this.textBoxLastHTTPResponse.TabIndex = 4;
            this.textBoxLastHTTPResponse.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last HTTP response";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(12, 25);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(211, 21);
            this.comboBoxPort.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Arduino COM Port";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(437, 9);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(193, 23);
            this.buttonConnect.TabIndex = 8;
            this.buttonConnect.Text = "Start servers";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.Location = new System.Drawing.Point(437, 38);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(193, 23);
            this.buttonDisconnect.TabIndex = 9;
            this.buttonDisconnect.Text = "Close servers";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // textBoxArduinoIn
            // 
            this.textBoxArduinoIn.Location = new System.Drawing.Point(324, 96);
            this.textBoxArduinoIn.Multiline = true;
            this.textBoxArduinoIn.Name = "textBoxArduinoIn";
            this.textBoxArduinoIn.ReadOnly = true;
            this.textBoxArduinoIn.Size = new System.Drawing.Size(150, 413);
            this.textBoxArduinoIn.TabIndex = 10;
            this.textBoxArduinoIn.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Arduino In";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Arduino Out";
            // 
            // textBoxArduinoOut
            // 
            this.textBoxArduinoOut.Location = new System.Drawing.Point(480, 96);
            this.textBoxArduinoOut.Multiline = true;
            this.textBoxArduinoOut.Name = "textBoxArduinoOut";
            this.textBoxArduinoOut.ReadOnly = true;
            this.textBoxArduinoOut.Size = new System.Drawing.Size(150, 413);
            this.textBoxArduinoOut.TabIndex = 12;
            this.textBoxArduinoOut.WordWrap = false;
            // 
            // buttonRefreshPort
            // 
            this.buttonRefreshPort.Image = global::SAS2_MW.Properties.Resources.refresh_16xLG;
            this.buttonRefreshPort.Location = new System.Drawing.Point(229, 19);
            this.buttonRefreshPort.Name = "buttonRefreshPort";
            this.buttonRefreshPort.Size = new System.Drawing.Size(30, 30);
            this.buttonRefreshPort.TabIndex = 14;
            this.buttonRefreshPort.UseVisualStyleBackColor = true;
            this.buttonRefreshPort.Click += new System.EventHandler(this.buttonRefreshPort_Click);
            // 
            // checkBoxViewPolling
            // 
            this.checkBoxViewPolling.AutoSize = true;
            this.checkBoxViewPolling.Location = new System.Drawing.Point(11, 515);
            this.checkBoxViewPolling.Name = "checkBoxViewPolling";
            this.checkBoxViewPolling.Size = new System.Drawing.Size(82, 17);
            this.checkBoxViewPolling.TabIndex = 17;
            this.checkBoxViewPolling.Text = "View polling";
            this.checkBoxViewPolling.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewSYNACK
            // 
            this.checkBoxViewSYNACK.AutoSize = true;
            this.checkBoxViewSYNACK.Location = new System.Drawing.Point(324, 515);
            this.checkBoxViewSYNACK.Name = "checkBoxViewSYNACK";
            this.checkBoxViewSYNACK.Size = new System.Drawing.Size(120, 17);
            this.checkBoxViewSYNACK.TabIndex = 15;
            this.checkBoxViewSYNACK.Text = "View SYN/ACK/OK";
            this.checkBoxViewSYNACK.UseVisualStyleBackColor = true;
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Location = new System.Drawing.Point(11, 538);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(81, 23);
            this.buttonClearLogs.TabIndex = 19;
            this.buttonClearLogs.Text = "Clear logs";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.buttonClearLogs_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 570);
            this.Controls.Add(this.buttonClearLogs);
            this.Controls.Add(this.checkBoxViewPolling);
            this.Controls.Add(this.checkBoxViewSYNACK);
            this.Controls.Add(this.textBoxLastHTTPResponse);
            this.Controls.Add(this.textBoxArduinoIn);
            this.Controls.Add(this.textBoxHTTPLog);
            this.Controls.Add(this.textBoxArduinoOut);
            this.Controls.Add(this.buttonRefreshPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "SAS2_MW";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHTTPLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLastHTTPResponse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox textBoxArduinoIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxArduinoOut;
        private System.Windows.Forms.Button buttonRefreshPort;
        private System.Windows.Forms.CheckBox checkBoxViewPolling;
        private System.Windows.Forms.CheckBox checkBoxViewSYNACK;
        private System.Windows.Forms.Button buttonClearLogs;
    }
}

