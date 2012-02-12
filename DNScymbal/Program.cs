using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace DNScymbal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Local Variables
            bool bIsService = IsService();

            // Are we a genuine service?
            if (bIsService)
            {
                // Run the service 
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new MainService() 
			    };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                // Run in interactive mode...
                DnsCymbalUpdater dcu = new DnsCymbalUpdater();
                dcu.Start();

                TrayIcon ti = new TrayIcon(dcu);
                ti.ShowDialog();
            }
        }

        static bool IsService()
        {
            ServiceController[] svcs = ServiceController.GetServices();
            foreach (ServiceController svc in svcs)
            {
                if (svc.ServiceName == "DNScymbal")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
