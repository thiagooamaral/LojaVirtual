using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private string Key = "Login.Colaborador";
        private Sessao.Sessao _sessao;

        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            //Serializar um objeto Colaborador para string. Para isso foi instalado via Nuget o pacote Newtonsoft.Json
            string colaboradorJSONString = JsonConvert.SerializeObject(colaborador);
            _sessao.Cadastrar(Key, colaboradorJSONString);
        }

        public Colaborador GetColaborador()
        {
            //Deserializar uma string para um objeto do tipo Colaborador
            if (_sessao.Existe(Key))
            {
                string colaboradorJSONString = _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSONString);
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
