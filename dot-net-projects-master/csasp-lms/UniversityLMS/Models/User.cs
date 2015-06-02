using System.ComponentModel.DataAnnotations;

public class User
{
    public int UserID { get; set; }

    [Display(Name="User Name")]
    [MaxLength(20)]
    [Required]
    public string UserName { get; set; }

    [Display(Name="Email Address")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(100)]
    [Required]
    public string EmailAddress { get; set; }

    [Display(Name="Password")]
    [DataType(DataType.Password)]
    [MaxLength(20)]
    [Required]
    public string Password { get; set; }

}