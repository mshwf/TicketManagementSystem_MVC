using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TicketManagementSystem_MVC.Helper;

namespace TicketManagementSystem_MVC.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        //It's beter using code generator than identity field as a ticket number
        //in case of droping the database or even not using it.
        public string TicketNumber { get; set; } = HelperClass.CreatePassword(6);
        [Required, Display(Name = "Name")]
        public string OwnerName { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [Required, Display(Name = "Model Number")]
        public string LaptopModelNumber { get; set; }
        [Required, StringLength(50)]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime TicketDate { get; set; } = DateTime.Now;

    }
}