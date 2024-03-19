using System.ComponentModel.DataAnnotations;

namespace MyCompanyAPI.DTOs
{
    public class ProjectDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
