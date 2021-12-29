using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileManager.Web.ViewModels;

public class OrganizationUserViewModel
{
    [DisplayName("Full Name")]
    [Required]
    public string Name { get; set; }
    public string Gender { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [DisplayName("Business Name")]
    public string OrgName { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Email { get; set; }
    public string Fax { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
}