using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Mvc;

namespace SameDayServicezFinal.Models
{
 
    [Table("LoginHistory")]
    public class LoginHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }
    }


    [Table("Categories")]
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string MainCatName { get; set; }

        [NotMapped]
        public string Url { get; set; }
        [NotMapped]
        public string FileName { get; set; }

        [NotMapped]
        public List<Subcategories> SubCatNames { get; set; }
    }

    [Table("Subcategories")]
    public class Subcategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long MainCatId { get; set; }

        public string SubCatNames { get; set; }
    }

    [Table("ContractorCustomerCategories")]
    public class ContractorCustomerCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ContractorCustomerId { get; set; }
        public long MainCatId { get; set; }

        public long SubCatId { get; set; }
        public string SubCatName { get; set; }
        public string MainCatName { get; set; }

    }


    [Table("ProjectCategories")]
    public class ProjectCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ProjectsUsersId { get; set; }
        public long ProjectsMainCatId { get; set; }
        public long ProjectsSubCatId { get; set; }
        public long ProjectsId { get; set; }
        public string ProjectsSubCatName { get; set; }
        public string ProjectsMainCatName { get; set; }

    }

    [Table("StateAndCityInfo")]
    public class StateInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string State { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string ZipCode { get; set; }
    }

    [Table("Projects")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProjectsId { get; set; }

        //[NotMapped]
        //public string JsonProjectsId { get; set; }

        [Required]
        public string ProjectsUsersId { get; set; }

        [Display(Name = "Project Title")]
        [Required]
        public string ProjectTitle { get; set; }
        [Required]
        public string Description { get; set; }


        public bool IsDraft { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }


        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> States { get; set; }

        [StringLength(5, MinimumLength = 5)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada

        [Display(Name = "Zip Code")]
        [Required]
        public string ZipCode { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Professions { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> SubProfessions { get; set; }

        [NotMapped]
        public List<ProjectCategories> ProjectCategories { get; set; }

        [NotMapped]
        public string JsonProfession { get; set; }

        public string InfoTabOpen { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdated { get; set; }

        public bool IsActive { get; set; }

        public long ProjectCompensationPackageId { get; set; }

        [NotMapped]
        public long SelectedProjectCompensationPackage { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> CompensationTypeList { get; set; }
        [NotMapped]
        public decimal ByTheHourRate { get; set; }
        [NotMapped]
        public decimal ByTheProjectRate { get; set; }
        [NotMapped]
        public decimal StartingBidRate { get; set; }
        [NotMapped]
        public decimal EndingBidRate { get; set; }
        [NotMapped]
        public decimal FloatingBidRate { get; set; }
        [NotMapped]
        public DateTime StartingBidDate { get; set; }
        [NotMapped]
        public DateTime EndingBidDate { get; set; }
        [NotMapped]
        public List<ProjectDocuments> ProjectDocuments { get; set; }
        [NotMapped]
        public ProjectCompensationPackage ProjectCompensationPackage { get; set; }

        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    [Table("ProjectAssignment")]
    public class ProjectAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UsersId { get; set; }
        public long ProjectId { get; set; }
        public string ProjectOwner { get; set; }
    }

    [Table("ProjectCompensationPackage")]
    public class ProjectCompensationPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UsersId { get; set; }
        public long ProjectId { get; set; }
        public long ProjectCompensationType { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal ByTheHourRate { get; set; }
        public decimal ByTheProjectRate { get; set; }
        public decimal StartingBidRate { get; set; }
        public decimal EndingBidRate { get; set; }
        public decimal FloatingBidRate { get; set; }
        public DateTime StartingBidDate { get; set; }
        public DateTime EndingBidDate { get; set; }
    }

    [Table("ProjectCompensations")]
    public class ProjectCompensations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CompensationTypeText { get; set; }
        public string CompensationTypeValue { get; set; }
    }



    [Table("ProjectDocuments")]
    public class ProjectDocuments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ProjectId { get; set; }
        public string ImageName { get; set; }

        public DateTime CreationDate { get; set; }
        public string UsersId { get; set; }

        public string ImageComment { get; set; }
    }

    public class JsonProjectDocumentList
    {
        public string ImageName { get; set; }
    }

    public class PortalList
    {

        public PortalList()
        {
            Projects = new List<Project>();
            ApplicationUser = new List<ApplicationUser>();
        }

        public List<Project> Projects { get; set; }
        public List<ApplicationUser> ApplicationUser { get; set; }




    }


    public class StarRating
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RateId { get; set; }

        public int Rate { get; set; }

        public string IpAddress { get; set; }

        public int ContractorId { get; set; }



    }
}