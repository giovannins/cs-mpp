using System.ComponentModel.DataAnnotations;

namespace cs_mpp.Models;

public class Contact
{
    public long Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(120, MinimumLength = 2, ErrorMessage = "O campo Nome deve ter entre 2 e 120 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Insira um endereço de email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Insira um número de telefone válido.")]
    public string? Phone { get; set; }

    [DataType(DataType.Date)]
    public DateTime Create_at { get; set; }
}