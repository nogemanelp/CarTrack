using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTrack_OMdbWebAPI.Utilities
{ 
    public class MetaData
    {
        public string APIKey { get; set; }
        public  MetaData()
        {
            APIKey = ConfigurationManager.AppSettings["APIKey"];
        }
          
    }
}
