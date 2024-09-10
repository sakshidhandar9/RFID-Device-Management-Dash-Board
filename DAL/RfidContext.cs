using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RFID_Device_Management.Models;
using System.Data.Entity;

namespace RFID_Device_Management.DAL
{
    
        public class RfidContext : DbContext
        {
            // Define DbSets for each table in the database
            public DbSet<RfidDevice> RfidDevices { get; set; }
            public DbSet<RfidTagRead> RfidTagReads { get; set; }
            public DbSet<User> Users { get; set;}

            // Constructor that uses the connection string defined in Web.config
            public RfidContext() : base("name=RfidContext")
            {

            }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the primary key
            modelBuilder.Entity<RfidTagRead>()
                .HasKey(r => r.Id); // Specify the primary key property

            base.OnModelCreating(modelBuilder);
        }




    }
}