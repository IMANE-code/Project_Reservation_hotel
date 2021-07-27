using fil_rouge.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace fil_rouge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Client> clients { get; set; }
        public virtual DbSet<Reservation_Hotel> reservation_Hotels { get; set; }
        public virtual DbSet<Hotel> hotels { get; set; }
    }
}
