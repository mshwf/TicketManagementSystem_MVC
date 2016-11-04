using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketManagementSystem_MVC.Models;

namespace TicketManagementSystem_MVC.DAL
{
    public class TicketSysContext : DbContext
    {
        public TicketSysContext():base("TMSConnection")
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
    }
}