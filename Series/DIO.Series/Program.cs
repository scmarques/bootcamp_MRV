using System;


namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
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
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!  :)");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {

            Console.WriteLine("Exclusão de série");
            Console.WriteLine();
            Console.WriteLine("Informe o ID da série que deseja excluir:");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("!!!!ATENÇÃO!!!!");
            Console.WriteLine("Tem certeza que deseja excluir a série abaixo:?");
            Console.WriteLine(repositorio.RetornaPorId(indiceSerie));
            Console.WriteLine();
            Console.WriteLine("Digite 1 para CONFIRMAR A EXCLUSÃO ou 2 para CANCELAR e retornar ao menu inicial.");
            var confirma = Console.ReadLine();
            switch(confirma)
            {
                case "1":
                    repositorio.Exclui(indiceSerie);
                    Console.WriteLine("Exclusão realizada.");
                    Console.ReadLine();
                    break;             
                case "2":
                    return;
                default:
                    Console.WriteLine("Valor inválido. Retornado ao menu principal.");
                    Console.ReadLine();
                    return;
            }
        }

        private static void VisualizarSerie (){

            Console.WriteLine("Visualização de série");
            Console.WriteLine();
            Console.WriteLine("Informe o ID da série que deseja visualizar:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie ()
        {
            Console.WriteLine("Atualização de série");
            Console.WriteLine();
            Console.WriteLine("Informe o ID da série que deseja atualizar:");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            Serie atualizaSerie = LeInformacaoSerie(indiceSerie);
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static Serie LeInformacaoSerie (int id){

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serieLida = new Serie(id: id,
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);
            
            return serieLida;
        }

        
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries:");
            Console.WriteLine();

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie novaSerie = LeInformacaoSerie(repositorio.ProximoId());

            repositorio.Insere(novaSerie);


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(":::::::::DIO Séries:::::::::");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
