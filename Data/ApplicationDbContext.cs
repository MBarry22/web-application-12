using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication12.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IPN> IPNs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
               base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    // Instant Payment Notification
    public class IPN
    {
        // This lets you link the request to paypal with the response.
        public string custom { get; set; }

        [Display(Name = "Payment ID")]
        [Key] // Define primary key.
        public string paymentID { get; set; }
        public string cart { get; set; }
        [Display(Name = "Created")]
        public string create_time { get; set; }

        // Payer data.
        public string payerID { get; set; }
        [Display(Name = "Name")]
        public string payerFirstName { get; set; }
        public string payerLastName { get; set; }
        public string payerMiddleName { get; set; }
        [Display(Name = "Email")]
        public string payerEmail { get; set; }
        public string payerCountryCode { get; set; }
        public string payerStatus { get; set; }

        // Payment data.
        [Display(Name = "Amount")]
        public string amount { get; set; }
        public string currency { get; set; }
        public string intent { get; set; }
        [Display(Name = "MOP")]
        public string paymentMethod { get; set; }
        public string paymentState { get; set; }
    }

}