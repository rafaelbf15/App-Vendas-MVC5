using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Domain.Validations.VendaEstoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Services
{
    public class VendaService : IVendaService
    {

        private readonly IVendaRepository _vendaRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IEstoqueRepository _estoqueRepository;

        public VendaService(IVendaRepository vendaRepository,
                        IEstoqueRepository estoqueRepository,
                        IEstoqueService estoqueService)
        {
            _vendaRepository = vendaRepository;
            _estoqueService = estoqueService;
            _estoqueRepository = estoqueRepository;
        }

        public Venda Adicionar(Venda venda)
        {
            if (!venda.EhValido()) return venda;

            venda.ValidationResult = new VendaCadastroOkValidation(_estoqueRepository,_vendaRepository).Validate(venda);

            if (venda.ValidationResult.IsValid)

                venda.DataVenda = DateTime.Now;
                _vendaRepository.Adicionar(venda);
                _estoqueService.RemoverQuantidadeProdutoEstoque(venda.ProdutoId, (int) venda.Quantidade);

            return venda;
        }

        public Venda Atualizar(Venda venda)
        {
            if (!venda.EhValido()) return venda;

            venda.ValidationResult = new VendaCadastroOkValidation(_estoqueRepository,_vendaRepository).Validate(venda);

            if (venda.ValidationResult.IsValid)

                venda.DataVenda = new DateTime();
                _vendaRepository.Atualizar(venda);
                _estoqueService.RemoverQuantidadeProdutoEstoque(venda.ProdutoId, (int) venda.Quantidade);

            return venda;
           
        }

        public void Remover(Guid id)
        {
            _vendaRepository.Remover(id);
        }

        public void Dispose()
        {
            _vendaRepository.Dispose();
        }
    }
}
