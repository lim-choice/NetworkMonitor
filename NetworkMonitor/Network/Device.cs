using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitor.Network
{
    class NetDevice
    {
        private static readonly Lazy<NetDevice> _instance = new Lazy<NetDevice>(() => new NetDevice());

        public static NetDevice Instance
        {
            get { return _instance.Value; }
        }

        private NetDevice() { }

        SharpPcap.ICaptureDevice selectDevice = null;

        public void Load()
        {
            string ver = SharpPcap.Version.VersionString;
            Console.WriteLine("Chapcturing System");

            // Retrieve the device list
            var devices = SharpPcap.CaptureDeviceList.Instance;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                Console.WriteLine("No devices were found on this machine");
                return;
            }

            Console.WriteLine("\nThe following devices are available on this machine:");
            Console.WriteLine("----------------------------------------------------\n");

            /* Scan the list printing every entry */
            foreach (var dev in devices)
            {
                Console.WriteLine("{0}\n", dev.ToString());
                selectDevice = dev;
                selectDevice.Open();
                break;
            }

            Console.Write("Hit 'Enter' to exit...");
            Console.ReadLine();
        }

        //수정 필요
        public string[] GetSelectedDeviceInfo()
        {
            return (
                new string[4] {
                    selectDevice.Description,
                    selectDevice.LinkType.ToString(),
                    "",
                    ""
                }
            );
        }
    }
}
