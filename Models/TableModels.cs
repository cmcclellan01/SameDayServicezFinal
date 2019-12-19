using SameDayServicezFinal.Utils;
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

        public Project()
        {
            ProjectApplicants = new List<ProjectApplicants>();
            ProjectRating = new List<ProjectRating>();
        }




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

        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Address")]

        public string Address { get; set; }


        [Display(Name = "City")]

        public string City { get; set; }

        [Display(Name = "State")]

        public string State { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> States { get; set; }

        [StringLength(5, MinimumLength = 5)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada

        [Display(Name = "Zip Code")]

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

        [AllowHtml]
        public string Notes { get; set; }

        [NotMapped]
        public List<ProjectAssignment> ProjectAssignments { get; set; }

        [NotMapped]
        public List<Conversations> Conversations { get; set; }
        [NotMapped]
        public string ProjectOwnerName { get; set; }

        public bool AcceptingContractors { get; set; }

        public int NumberOfContractorsNeeded { get; set; }

        public int NumberOfDaysHelpIsNeeded { get; set; }

        public long Duration { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> DurationList { get; set; }

        [NotMapped]
        public List<ProjectApplicants> ProjectApplicants { get; set; }

        public ProjectStatuses ProjectStatus { get; set; }

        public bool IsProjectPublished { get; set; }

        [NotMapped]
        public bool HasApplicants { get; set; }

        [NotMapped]
        public int ApplicantCount { get; set; }

        [NotMapped]
        public List<ProjectRating> ProjectRating { get; set; }
    }

    public enum ProjectStatuses
    {
        Completed,
        Active,
        Draft,
        Closed
    }
    public class ProjectPosting
    {
        public string ProjectTitle { get; set; }
        public long ProjectId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public bool Read { get; set; }
        public bool Delivered { get; set; }
    }


    [Table("ProjectApplicants")]
    public class ProjectApplicants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ProjectsId { get; set; }

        public string ApplicantId { get; set; }

        [NotMapped]
        public ApplicationUser Applicant { get; set; }

        [NotMapped]
        public List<Project> PastProjects { get; set; }

        public DateTime AppliedDate { get; set; }

        public bool AssinedToProject { get; set; }

        public string ApplicantMessage { get; set; }

        public int ApplicantRating { get; set; }

        public bool Rejected { get; set; }
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
        [NotMapped]
        public string ProfileImage { get; set; }
        [NotMapped]
        public string ProfileDisplayName { get; set; }

        [NotMapped]
        public string ProfileBios { get; set; }
        [NotMapped]
        public int ProfileRating { get; set; }
        [NotMapped]
        public decimal ByTheHourRate { get; set; }
        [NotMapped]
        public List<Project> ProfilePastProjects { get; set; }
        [NotMapped]
        public string ProjectOwnerName { get; set; }

        [NotMapped]
        public List<ContractorCustomerCategories> ProfileProfessions { get; set; }
    }


    [Table("Conversations")]
    public class Conversations
    {
        public Conversations()
        {
            Message = new List<Messages>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string ConversationOwnerId { get; set; }
        public string ConversationSubOwnerId { get; set; }
        public List<Messages> Message { get; set; }

        [NotMapped]
        public ApplicationUser ConversationOwner { get; set; }

        [NotMapped]
        public ApplicationUser ConversationSubOwner { get; set; }

        [NotMapped]
        public int SenderUnreadMessageCount { get; set; }

        [NotMapped]
        public string SenderProfileDisplayName { get; set; }
        [NotMapped]
        public string SenderProfileDisplayImage { get; set; }


        [NotMapped]
        public int ReceiverUnreadMessageCount { get; set; }

        [NotMapped]
        public string ReceiverProfileDisplayName { get; set; }
        [NotMapped]
        public string ReceiverProfileDisplayImage { get; set; }
        [NotMapped]
        public bool IsinContractorMode { get; set; }
    }

    [Table("Messages")]
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [AllowHtml]
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public bool Read { get; set; }
        public bool Delivered { get; set; }
        public long ConversationsId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        [NotMapped]
        public string ReceiverDisplayName { get; set; }
        [NotMapped]
        public string SenderDisplayName { get; set; }
        [NotMapped]
        public string JosnDateTime { get; set; }

    }

    [Table("ProjectRating")]
    public class ProjectRating
    {

        public ProjectRating()
        {
            ProjectOwner = new ApplicationUser();
            Project = new Project();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public long ProjectsId { get; set; }
        public string ProjectOwnerId { get; set; }
        public string ContractorId { get; set; }
        public int Rating { get; set; }
        public string ProjectOwnerComment { get; set; }
        [NotMapped]
        public ApplicationUser ProjectOwner { get; set; }

        [NotMapped]
        public Project Project { get; set; }

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
            ApplicationUser = new ApplicationUser();
            ContractorList = new List<ContractorSearchList>();
            Conversations = new List<Conversations>();
            ProjectApplies = new List<ProjectPosting>();
            message = new Messages();
            ProjectRating = new List<ProjectRating>();
        }

        public List<Project> Projects { get; set; }     
        public ApplicationUser ApplicationUser { get; set; }
        public List<ContractorSearchList> ContractorList { get; set; }

        public List<Conversations> Conversations { get; set; }
        public Pager Pager { get; set; }

        public List<ProjectPosting> ProjectApplies { get; set; }

        public Messages message { get; set; }

        public List<ProjectRating> ProjectRating { get; set; }
    }

   

    public class ContractorSearchList
    {
        public ApplicationUser Contractor { get; set; }
        public List<Project> PastProjects { get; set; }

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