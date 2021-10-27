using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charon
{
    public class InstalledClient
    {
        public InstalledClient() { }
        public InstalledClient(string pcName)
        {
            name = pcName;
        }
        public int id { get; set; }
        public string securityIdentifier { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class PrinterResponse
    {
        public PrinterResponse() { }
        public PrinterResponse(string message, string pcName)
        {
            installedPrinters = new List<InstalledPrinter>();
            installedPrinters.Add(new InstalledPrinter(message));
            installedClients = new List<InstalledClient>();
            installedClients.Add(new InstalledClient(pcName));
        }
        public List<InstalledPrinter> installedPrinters { get; set; }
        public List<InstalledClient> installedClients { get; set; }
        public List<object> installedUsers { get; set; }
        public List<object> installedMobileDevice { get; set; }
    }


}
