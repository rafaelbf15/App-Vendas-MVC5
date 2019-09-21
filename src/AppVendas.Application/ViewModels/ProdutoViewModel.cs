using System;
using System.ComponentModel.DataAnnotations;

namespace AppVendas.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
        public string Nome { get; set; }

        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria de produto")]
        [Display(Name = "Categoria")]
        public Guid CategoriaId { get; set; }

        [ScaffoldColumn(false)]
        public CategoriaViewModel Categoria { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

    }
}
