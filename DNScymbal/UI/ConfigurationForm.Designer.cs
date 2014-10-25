namespace DNScymbal
{
    partial class ConfigurationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDNSimple = new System.Windows.Forms.TabPage();
            this.tableGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._txtEmailAddr = new System.Windows.Forms.TextBox();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableDnsRecord = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._txtRecordName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtRecordId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._txtDomain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._cbIpAddress = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this._txtUpdateFreq = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._chkEnableDNSimple = new System.Windows.Forms.CheckBox();
            this._chkAutoStartApp = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._chkIsApiToken = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabDNSimple.SuspendLayout();
            this.tableGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableDnsRecord.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDNSimple);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.HotTrack = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabDNSimple
            // 
            this.tabDNSimple.Controls.Add(this.tableGeneral);
            resources.ApplyResources(this.tabDNSimple, "tabDNSimple");
            this.tabDNSimple.Name = "tabDNSimple";
            this.tabDNSimple.UseVisualStyleBackColor = true;
            // 
            // tableGeneral
            // 
            resources.ApplyResources(this.tableGeneral, "tableGeneral");
            this.tableGeneral.Controls.Add(this.groupBox1, 0, 2);
            this.tableGeneral.Controls.Add(this.groupBox2, 0, 3);
            this.tableGeneral.Controls.Add(this.groupBox3, 0, 4);
            this.tableGeneral.Controls.Add(this._chkEnableDNSimple, 0, 1);
            this.tableGeneral.Controls.Add(this._chkAutoStartApp, 0, 0);
            this.tableGeneral.Name = "tableGeneral";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this._txtEmailAddr, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this._txtPassword, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this._chkIsApiToken, 1, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _txtEmailAddr
            // 
            resources.ApplyResources(this._txtEmailAddr, "_txtEmailAddr");
            this._txtEmailAddr.Name = "_txtEmailAddr";
            // 
            // _txtPassword
            // 
            resources.ApplyResources(this._txtPassword, "_txtPassword");
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.UseSystemPasswordChar = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableDnsRecord);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tableDnsRecord
            // 
            resources.ApplyResources(this.tableDnsRecord, "tableDnsRecord");
            this.tableDnsRecord.Controls.Add(this.label4, 0, 2);
            this.tableDnsRecord.Controls.Add(this._txtRecordName, 1, 2);
            this.tableDnsRecord.Controls.Add(this.label3, 0, 1);
            this.tableDnsRecord.Controls.Add(this._txtRecordId, 1, 1);
            this.tableDnsRecord.Controls.Add(this.label7, 0, 0);
            this.tableDnsRecord.Controls.Add(this._txtDomain, 1, 0);
            this.tableDnsRecord.Controls.Add(this.label8, 0, 3);
            this.tableDnsRecord.Controls.Add(this._cbIpAddress, 1, 3);
            this.tableDnsRecord.Name = "tableDnsRecord";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _txtRecordName
            // 
            resources.ApplyResources(this._txtRecordName, "_txtRecordName");
            this._txtRecordName.Name = "_txtRecordName";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _txtRecordId
            // 
            resources.ApplyResources(this._txtRecordId, "_txtRecordId");
            this._txtRecordId.Name = "_txtRecordId";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // _txtDomain
            // 
            resources.ApplyResources(this._txtDomain, "_txtDomain");
            this._txtDomain.Name = "_txtDomain";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // _cbIpAddress
            // 
            resources.ApplyResources(this._cbIpAddress, "_cbIpAddress");
            this._cbIpAddress.DropDownHeight = 200;
            this._cbIpAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbIpAddress.DropDownWidth = 350;
            this._cbIpAddress.FormattingEnabled = true;
            this._cbIpAddress.Name = "_cbIpAddress";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel6);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this._txtUpdateFreq, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // _txtUpdateFreq
            // 
            resources.ApplyResources(this._txtUpdateFreq, "_txtUpdateFreq");
            this._txtUpdateFreq.Name = "_txtUpdateFreq";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _chkEnableDNSimple
            // 
            resources.ApplyResources(this._chkEnableDNSimple, "_chkEnableDNSimple");
            this._chkEnableDNSimple.Name = "_chkEnableDNSimple";
            this._chkEnableDNSimple.UseVisualStyleBackColor = true;
            this._chkEnableDNSimple.CheckedChanged += new System.EventHandler(this._chkEnableDNSimple_CheckedChanged);
            // 
            // _chkAutoStartApp
            // 
            resources.ApplyResources(this._chkAutoStartApp, "_chkAutoStartApp");
            this._chkAutoStartApp.Name = "_chkAutoStartApp";
            this._chkAutoStartApp.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this._btnOk, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this._btnCancel, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // _btnOk
            // 
            resources.ApplyResources(this._btnOk, "_btnOk");
            this._btnOk.Name = "_btnOk";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._btnCancel, "_btnCancel");
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _chkIsApiToken
            // 
            resources.ApplyResources(this._chkIsApiToken, "_chkIsApiToken");
            this._chkIsApiToken.Name = "_chkIsApiToken";
            this._chkIsApiToken.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this._btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDNSimple.ResumeLayout(false);
            this.tableGeneral.ResumeLayout(false);
            this.tableGeneral.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableDnsRecord.ResumeLayout(false);
            this.tableDnsRecord.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDNSimple;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtEmailAddr;
        private System.Windows.Forms.TextBox _txtPassword;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableDnsRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtRecordName;
        private System.Windows.Forms.TextBox _txtRecordId;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtUpdateFreq;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _txtDomain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _cbIpAddress;
        private System.Windows.Forms.CheckBox _chkEnableDNSimple;
        private System.Windows.Forms.CheckBox _chkAutoStartApp;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.CheckBox _chkIsApiToken;
    }
}