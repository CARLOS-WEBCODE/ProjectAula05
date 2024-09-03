using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Exceptions
{
    /// <summary>
    /// Classe customizada para erros de validação do projeto
    /// </summary>
    public class ValidationException : Exception
    {
        //atributo
        private readonly string _mensagem;

        public ValidationException(string mensagem)
        {
            _mensagem = mensagem;
        }

        //sobrescrita do método da classe Exception
        public override string Message => $"Ocorreu um erro de validação: ";
    }
}
