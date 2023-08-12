using System.ComponentModel.DataAnnotations;

namespace cs_mpp.Models;

public class Product
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(120, MinimumLength = 2, ErrorMessage = "O campo Nome deve ter entre 2 e 120 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O campo Preço é obrigatório.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "O campo Imagem deve conter no minimo uma")]
    [MinLength(1)]
    public string Image { get; set; }
}