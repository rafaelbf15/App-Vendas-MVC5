using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
