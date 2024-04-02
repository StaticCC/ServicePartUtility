using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartChecker
{
    public class Part
    {
        public string Id { get; set; }
        public string PartNum { get; set; }
        public string ETA { get; set; }
        public string Status { get; set; }

        // Constructor with parameters
        public Part(string id, string partnumber, string eta, string status)
        {
            Id = id;
            PartNum = partnumber;
            ETA = eta; 
            Status = status;
            
        }
    }
}
