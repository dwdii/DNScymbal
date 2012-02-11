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
            bool bIsService = false;

            // Are we a genuine service?
            if (bIsService)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			{ 
				new MainService() 
			};
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                DnsCymbalUpdater dcu = new DnsCymbalUpdater();
                dcu.Start();
            }
        }
    }
}
