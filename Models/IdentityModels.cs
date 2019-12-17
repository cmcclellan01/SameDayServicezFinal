using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SameDayServicezFinal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; }
        public string Bio { get; set; }
        public bool IsInContractorMode { get; set; }
        public bool IsInCustomerMode { get; set; }
        public int PercentDone { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> States { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Skills { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Professions { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SubProfessions { get; set; }

        [NotMapped]
        public List<ContractorCustomerCategories> UserProfessions { get; set; }

        [NotMapped]
        public string JsonProfession { get; set; }

        public string InfoTabOpen { get; set; }

        public string ProfileImage { get; set; }
        public string IdImage { get; set; }

        public double latitude { get; set; }
        public double longitude { get; set; }

        public decimal ByTheHourRate { get; set; }

        public int Rating { get; set; }
        public string RatingClass { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [NotMapped]
        public string OldPassword { get; set; }

        [NotMapped]
        public string NewPassword { get; set; }
        public string DisplayName { get; set; }

        public bool InWorkMode { get; set; }

        public bool Online { get; set; }

        public string ProfileResume { get; set; }

        [NotMapped]
        public List<Conversations> Conversations { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Subcategories> Subcategories { get; set; }
        public DbSet<ContractorCustomerCategories> ContractorCustomerCategories { get; set; }
        public DbSet<ProjectCategories> ProjectCategories { get; set; }

        public DbSet<StateInfo> StateInfo { get; set; }
        public DbSet<Project> Project { get; set; }

        public DbSet<ProjectDocuments> ProjectDocuments { get; set; }

        public DbSet<ProjectCompensationPackage> ProjectCompensationPackage { get; set; }

        public DbSet<ProjectCompensations> ProjectCompensations { get; set; }

        public DbSet<ProjectAssignment> ProjectAssignment { get; set; }

        public DbSet<Conversations> Conversations { get; set; }
        public DbSet<Messages> Messages { get; set; }

        public DbSet<ProjectApplicants> ProjectApplicants { get; set; }

        public DbSet<ProjectRating> ProjectRating { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}