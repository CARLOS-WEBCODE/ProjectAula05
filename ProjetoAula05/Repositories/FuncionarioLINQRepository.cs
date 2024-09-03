using ProjetoAula05.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Repositories
{
    public class FuncionarioLINQRepository : FuncionarioAbstractRepository
    {
        public override void Adicionar(Funcionario funcionario)
        {
            //adicionando o fncionario na lista
            Funcionarios.Add(funcionario);
        }

        public override void Atualizar(Funcionario funcionario)
        {
            //buscando o funcionario pelo id
            var item = ObterPorId(funcionario.Id);

            //verificando se o funcionário não foi encontrado
            if (item == null) throw new Exception("Funcionário não encontrado.");

            //alterando os dados
            item.Nome= funcionario.Nome;
            item.Cpf= funcionario.Cpf;
            item.Matricula= funcionario.Matricula;
            item.DataAdmissao = funcionario.DataAdmissao;
            item.Tipo = funcionario.Tipo;
        }

        public override void Remover(Funcionario funcionario)
        {
            //buscando o funcionario pelo id
            var item = ObterPorId(funcionario.Id);

            //verificando se o funcionário não foi encontrado
            if (item == null) throw new Exception("Funcionário não encontrado.");

            //removendo o funcionário
            Funcionarios.Remove(item);
        }

        public override List<Funcionario> ObterTodos()
        {
            //SINTAXE LINQ
            var query = from f in Funcionarios
                        orderby f.Nome ascending
                        select f;

            return query.ToList();
        }

        public override List<Funcionario> ObterPorNome(string nome)
        {
            var query = from f in Funcionarios
                        where f.Nome.Contains(nome)
                        orderby f.Nome ascending
                        select f;

            return query.ToList();
        }

        public override List<Funcionario> ObterPorDataAdmissao(DateTime? dataMin, DateTime? dataMax)
        {
            var query = from f in Funcionarios
                        where f.DataAdmissao >= dataMin
                        && f.DataAdmissao <= dataMax
                        orderby f.DataAdmissao ascending
                        select f;

            return query.ToList();
        }

        public override Funcionario ObterPorId(Guid id)
        {
            var query = from f in Funcionarios
                        where f.Id == id
                        select f;

            return query.FirstOrDefault();
        }

    }
}
