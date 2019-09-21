using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Application.ViewModels
{
    public class VendaViewModel
    {
        public VendaViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Selecione o produto")]
        [Display(Name="Produto")]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "Selecione a quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Data da venda")]
        [ScaffoldColumn(false)]
        public DateTime DataVenda { get; set; }

        [ScaffoldColumn(false)]
        public ProdutoViewModel Produto { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
