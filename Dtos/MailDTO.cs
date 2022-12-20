using System.ComponentModel.DataAnnotations;

namespace Portfolio2.Dtos;

public class MailDTO
{
    [Display(Name = "full name")]
    [Required(ErrorMessage = "please enter your {0}")]
    [MaxLength(200, ErrorMessage = "{0} can not be more than {1} character")]
    public string FullName { get; set; }

    [Display(Name = "email address")]
    [Required(ErrorMessage = "please enter your {0}")]
    [MaxLength(200, ErrorMessage = "{0} can not be more than {1} character")]
    [EmailAddress(ErrorMessage = "please enter a valid {0}")]
    public string Email { get; set; }

    [Display(Name = "subject")]
    [Required(ErrorMessage = "please enter the {0}")]
    [MaxLength(200, ErrorMessage = "{0} can not be more than {1} character")]
    public string Subject { get; set; }

    [Display(Name = "message")]
    [Required(ErrorMessage = "please enter the {0}")]
    [MaxLength(200, ErrorMessage = "{0} can not be more than {1} character")]
    public string Message { get; set; }
}
