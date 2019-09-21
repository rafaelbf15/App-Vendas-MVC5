using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Domain.Specifications.VendaEstoque;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Validations.VendaEstoque
{
    public class VendaCadastroOkValidation : Validator<Venda>
    {

        public VendaCadastroOkValidation(IEstoqueRepository estoqueRepository, IVendaRepository vendaRepository)
        {
            var quantidadeProdutoInsuficiente = new EstoqueDeveTerQuantidadeProduto(estoqueRepository, vendaRepository);

            Add("quantidadeProdutoInsuficiente", new Rule<Venda>(quantidadeProdutoInsuficiente, "Quantidade de produto no estoque insuficiente."));
        }

    }
}
