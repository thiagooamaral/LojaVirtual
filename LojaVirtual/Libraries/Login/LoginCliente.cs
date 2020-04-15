using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string Key = "Login.Cliente";
        private Sessao.Sessao _sessao;

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //Serializar um objeto Cliente para string. Para isso foi instalado via Nuget o pacote Newtonsoft.Json
            string clienteJSONString = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(Key, clienteJSONString);
        }

        public Cliente GetCliente()
        {
            //Deserializar uma string para um objeto do tipo Cliente
            if (_sessao.Existe(Key))
            {
                string clienteJSONString = _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
