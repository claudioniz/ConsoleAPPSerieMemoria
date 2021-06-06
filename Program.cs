using DadoMemoria.Enumeradores;
using DadoMemoria.Models;
using DadoMemoria.Repository;
using System;
using System.Linq;

namespace DadoMemoria
{
    class Program
    {
        static SerieRepository serieRepository = new SerieRepository(new System.Collections.Generic.List<Serie>());
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        ValorInvalido();
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void InformeGenero()
        {
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            var novaSerie = InformarDadosSerie(serieRepository.ObterProximoId());
            serieRepository.Adicionar(novaSerie);
            MensagemSucesso("adicionada");
            ListarSeries();
        }
        private static Serie InformarDadosSerie(int indiceSerie)
        {
            int entradaGenero = 15;
            do
            {
                InformeGenero();
                if (int.TryParse(Console.ReadLine(), out int valorInformado))
                {
                    entradaGenero = valorInformado;
                }
            } while (entradaGenero > 13);

            string entradaTitulo;
            do
            {
                Console.Write("Digite o Título da Série: ");
                entradaTitulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(entradaTitulo));

            int entradaAno = DateTime.Now.Year + 1;
            do
            {
                Console.Write($"Digite o Ano de Início da Série entre 1900 e {DateTime.Now.Year}: ");
                if (int.TryParse(Console.ReadLine(), out int valorInformado))
                {
                    entradaAno = valorInformado;
                }
            } while (entradaAno > DateTime.Now.Year || entradaAno < 1900);

            string entradaDescricao;
            do
            {
                Console.Write("Digite a Descrição da Série: ");
                entradaDescricao = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(entradaDescricao));

            Serie serie = new(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            return serie;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = serieRepository.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            Console.Write($"{"ID".PadRight(3, ' ')}");
            Console.Write($"{"GÊNERO".PadRight(20, ' ')}");
            Console.Write($"{"TÍTULO".PadRight(25, ' ')}");
            Console.Write($"{"DESCRIÇÃO".PadRight(30, ' ')}");
            Console.Write($"{"ANO".PadRight(5, ' ')}");
            Console.Write($"{"EXCLUÍDO".PadRight(7, ' ')}");
            Console.WriteLine();
            foreach (var serie in lista)
            {
                Console.WriteLine(serie.DadosSerie());
            }
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = serieRepository.ObterPorId(indiceSerie);
            if (serie == null)
            {
                Console.WriteLine("Id da série não encontrado.");
            }
            else
            {
                serieRepository.Excluir(indiceSerie);
                MensagemSucesso("excluida");
                ListarSeries();
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = 0;

            if(int.TryParse(Console.ReadLine(), out int valorInformado))
            {
                indiceSerie = valorInformado;
                var serie = serieRepository.ObterPorId(indiceSerie);
                if (serie == null)
                {
                    Console.WriteLine("Id da série não encontrado.");
                }
                else
                {
                    Console.WriteLine(serie);
                }
            }
            else
            {
                ValorInvalido();
            }
        }

        private static void ValorInvalido()
        {
            Console.WriteLine("Valor informado inválido!!!");
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = 0;

            if (int.TryParse(Console.ReadLine(), out int valorInformado))
            {
                indiceSerie = valorInformado;
                var serie = serieRepository.ObterPorId(indiceSerie);
                if (serie == null)
                {
                    Console.WriteLine("Id da série não encontrado.");
                    return;
                }

                var atualizaSerie = InformarDadosSerie(indiceSerie);

                serieRepository.Atualizar(indiceSerie, atualizaSerie);
                MensagemSucesso("atualizada");
                ListarSeries();
            }
            else
            {
                ValorInvalido();
            }
        }

        private static void MensagemSucesso(string mensagem)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"################# Série {mensagem} com sucesso!!! #################");
            Console.WriteLine();
        }
    }
}
