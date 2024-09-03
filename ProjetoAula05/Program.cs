using ProjetoAula05.Entities;
using ProjetoAula05.Enums;
using ProjetoAula05.Exceptions;
using ProjetoAula05.Repositories;
using System;

namespace ProjetoAula05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var funcionario1 = new Funcionario()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Sergio Mendes",
                    Cpf = "12345678900",
                    Matricula = "1234",
                    DataAdmissao = DateTime.Now,
                    Tipo = TipoContratacao.CLT
                };

                var funcionario2 = new Funcionario()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Ana Paula",
                    Cpf = "98723451678",
                    Matricula = "1357",
                    DataAdmissao = DateTime.Now,
                    Tipo = TipoContratacao.ESTAGIO
                };

                var funcionario3 = new Funcionario()
                {
                    Id = Guid.NewGuid(),
                    Nome = "João Pedro",
                    Cpf = "78965127823",
                    Matricula = "4321",
                    DataAdmissao = DateTime.Now,
                    Tipo = TipoContratacao.TERCEIRIZADO
                };

                Console.Write("INFORME (1)LAMBDA OU (2)LINQ....: ");
                var opcao = int.Parse(Console.ReadLine());

                //criando um objeto da classe abstrata utilizando POLIMORFISMO
                FuncionarioAbstractRepository funcionarioRepository = null;

                switch (opcao)
                {
                    case 1:
                        //POLIMORFISMO!
                        funcionarioRepository
                            = new FuncionarioLAMBDARepository();
                        break;
                    case 2:
                        //POLIMORFISMOo!
                        funcionarioRepository
                            = new FuncionarioLINQRepository();
                        break;
                    default:
                        throw new Exception("Opção inválida!");
                }

                //adicionar os funcionarios
                funcionarioRepository.Adicionar(funcionario1);
                funcionarioRepository.Adicionar(funcionario2);
                funcionarioRepository.Adicionar(funcionario3);

                //imprimindo os funcionarios
                foreach (var item in funcionarioRepository.ObterTodos())
                {
                    Console.WriteLine("\nFuncionário:");
                    Console.WriteLine($"ID.................: {item.Id}");
                    Console.WriteLine($"NOME...............: {item.Nome}");
                    Console.WriteLine($"CPF................: {item.Cpf}");
                    Console.WriteLine($"MATRICULA..........: {item.Matricula}");
                    Console.WriteLine($"DATA DE ADMISSÃO...: { item.DataAdmissao}");
                    Console.WriteLine($"TIPO...............: {item.Tipo}");
                }

                //verificando a instancia da variavel
                if (funcionarioRepository is FuncionarioLAMBDARepository)
                {
                    Console.WriteLine("\nPROCESSO REALIZADO COM LAMBDA");
                }
                else if (funcionarioRepository is FuncionarioLINQRepository)
                {
                    Console.WriteLine("\nPROCESSO REALIZADO COM LINQ");
                }
            }

            catch (ValidationException e)
            {
                Console.WriteLine("\nERRO DE VALIDAÇÃO DE DADOS:");
                Console.WriteLine(e.Message);
            }

            catch(Exception e)
            {
                Console.WriteLine("\nFALHA");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
