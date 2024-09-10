using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RFID_Device_Management.Models
{
    public class RfidDevice
    {
        public int Id { get; set; }  
        public string DeviceName { get; set; }  
        public string DeviceType { get; set; }  
        public string UniqueIdentifier { get; set; } 
        public string Location { get; set; }  
        public string Status { get; set; }  
    }
}
