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

    }
}
