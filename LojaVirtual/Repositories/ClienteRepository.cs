using System.Linq;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private LojaVirtualContext _banco;
        private IConfiguration _configuration;

        public ClienteRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _configuration = configuration;
        }

        public void Atualizar(Cliente cliente)
        {
            _banco.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _banco.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Cliente cliente = ObterCliente(Id);
            _banco.Remove(cliente);
            _banco.SaveChanges();
        }

        public Cliente Login(string Email, string Senha)
        {
            Cliente cliente = _banco.Clientes.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return cliente;
        }

        public Cliente ObterCliente(int Id)
        {
            return _banco.Clientes.Find(Id);
        }

        public IPagedList<Cliente> ObterTodosClientes(int? pagina, string pesquisa)
        {
            int RegistroPorPagina = _configuration.GetValue<int>("RegistroPorPagina");
            int NumeroPagina = pagina ?? 1;

            //AsQueryable: é o tipo de retorno após usar o where logo abaixo, já fiz a conversão aqui para não dar erro
            var bancoCliente = _banco.Clientes.AsQueryable(); 

            if (!string.IsNullOrEmpty(pesquisa))
            {
                bancoCliente = bancoCliente.Where(a => a.Nome.Contains(pesquisa.Trim()) || a.Email.Contains(pesquisa.Trim()));
            }

            return bancoCliente.ToPagedList<Cliente>(NumeroPagina, RegistroPorPagina);
        }
    }
}
