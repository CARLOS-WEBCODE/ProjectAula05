using ProjetoAula05.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Repositories
{
    public class FuncionarioLAMBDARepository : FuncionarioAbstractRepository
    {
        public override void Adicionar(Funcionario funcionario)
        {
            //adicionando o funcionario na lista
            Funcionarios.Add(funcionario);
        }

        public override void Atualizar(Funcionario funcionario)
        {
            var item = ObterPorId(funcionario.Id);

            if (item == null) throw new Exception("Funcionário não encontrado.");

            item.Nome = funcionario.Nome;
            item.Cpf = funcionario.Cpf;
            item.Matricula = funcionario.Matricula;
            item.DataAdmissao = funcionario.DataAdmissao;
            item.Tipo = funcionario.Tipo;
        }

        public override void Remover(Funcionario funcionario)
        {
            //buscando o funcionário pelo id
            var item = ObterPorId(funcionario.Id);
            
            //verificando se o funcionário não foi encontrado
            if (item == null)
                throw new Exception("Funcionário não encontrado.");
            
            //removendo o funcionario
            Funcionarios.Remove(item);

        }

        public override List<Funcionario> ObterTodos()
        {
            return Funcionarios.OrderBy(f => f.Nome).ToList();
        }

        public override List<Funcionario> ObterPorNome(string nome)
        {
            return Funcionarios.Where(f => f.Nome.Contains(nome)).OrderBy(f => f.Nome).ToList();
        }

        public override List<Funcionario> ObterPorDataAdmissao(DateTime? dataMin, DateTime? dataMax)
        {
            return Funcionarios
                .Where(f => f.DataAdmissao >= dataMin && f.DataAdmissao <= dataMax)
                .OrderByDescending(f => f.DataAdmissao)
                .ToList();
        }

        public override Funcionario ObterPorId(Guid id)
        {
            return Funcionarios
                .FirstOrDefault(f => f.Id == id);
        }

    }
}
