using System.ComponentModel.DataAnnotations;

namespace cs_mpp.Models;

public class Contact
{
    public long Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [Phone]
    public string? Phone { get; set; }
    [DataType(DataType.Date)]
    public DateTime Create_at { get; set; }
}