using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RFID_Device_Management.Models
{
    public class User
    {
        internal readonly object HashPassword;

        public int Id { get; set; }  
        public string Username { get; set; }  
        public string PasswordHash { get; set; } 
        public string Email { get; set; }  

    }
}
