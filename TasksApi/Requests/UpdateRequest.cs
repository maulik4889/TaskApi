using System.ComponentModel.DataAnnotations;

namespace TasksApi.Requests
{
    public class UpdateRequest
    {
        [StringLength(50, MinimumLength = 5), Required]
        public string? forename { get; set; }

        [StringLength(50, MinimumLength = 5), Required]
        public string? surname { get; set; }

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
    }
}
