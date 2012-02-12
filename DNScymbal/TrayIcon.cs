using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNScymbal
{
    class TrayIcon : Form
    {
        NotifyIcon _notifyIcon;
        ContextMenu _contextMenu;
        private Label label1;
        DnsCymbalUpdater _dcu;

        public TrayIcon(DnsCymbalUpdater dcu)
        {
            _dcu = dcu;
            Init();
        }

        private void Init()
        {
            _contextMenu = new ContextMenu();
            _contextMenu.MenuItems.Add(0, new MenuItem("Exit", new System.EventHandler(Exit_Click)));

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "DNScymbal";
            _notifyIcon.Visible = true;
            _notifyIcon.Icon = Properties.Resources.DNScymbal;
            _notifyIcon.ContextMenu = _contextMenu;

            // Make the window invisible.
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.FormClosed += new FormClosedEventHandler(TrayIcon_FormClosed);
            this.Shown += new EventHandler(TrayIcon_Shown);
        }

        void TrayIcon_Shown(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
        }

        void TrayIcon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit_Click(sender, e);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigSettings cs = new ConfigSettings();

                cs.Save();

                _dcu.Stop();

                _notifyIcon.Visible = false;
                this.Close();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception e)
        {
            MessageBox.Show(e.Message, _notifyIcon.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This form is a placeholder to enable the Tray Icon functionality.";
            // 
            // TrayIcon
            // 
            this.ClientSize = new System.Drawing.Size(348, 110);
            this.Controls.Add(this.label1);
            this.Name = "TrayIcon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
