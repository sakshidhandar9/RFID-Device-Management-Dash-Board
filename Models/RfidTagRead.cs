using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RFID_Device_Management.Models
{
    public class RfidTagRead
    {
        public int Id { get; set; } 
        public int DeviceId { get; set; }
        public DateTime ReadTimestamp { get; set; }
        public string Location { get; set; }
        public string ReaderId { get; set; }
    }
}