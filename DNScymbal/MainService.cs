using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;


namespace DNScymbal
{
    public partial class MainService : ServiceBase
    {
        DnsCymbalUpdater dcu = new DnsCymbalUpdater();

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            dcu.Start();

        }

        protected override void OnStop()
        {
            dcu.Stop();
        }

        
    }
}
