using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketManagementSystem_MVC.Models
{
    public class Ticket
    {
        [Key]
        public int TicketNumber { get; set; }
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