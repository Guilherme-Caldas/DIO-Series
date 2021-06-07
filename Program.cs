using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            int opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario >= 1 && opcaoUsuario <= 7)
			{
				switch (opcaoUsuario)
				{
					case 1:
						ListarSeries();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 2:
						InserirSerie();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 3:
						AtualizarSerie();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 4:
						ExcluirSerie();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 5:
						VisualizarSerie();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 6:
						Console.Clear();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 7:
						{ 
						Console.WriteLine();
						Console.WriteLine("Obrigado por utilizar nossos serviços.");
						Console.WriteLine();
						Console.WriteLine("Saindo da DIO Séries");
						break;
						}
						
				}
			}
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static int ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();

			Console.WriteLine("(1) - Listar séries");
			Console.WriteLine("(2) - Inserir nova série");
			Console.WriteLine("(3) - Atualizar série");
			Console.WriteLine("(4) - Excluir série");
			Console.WriteLine("(5) - Visualizar série");
			Console.WriteLine("(6) - Limpar Tela");
			Console.WriteLine("(7) - Sair (Exit)");
			Console.WriteLine();

			int opcaoUsuario = Int32.Parse(Console.ReadLine());

			while (opcaoUsuario < 1 || opcaoUsuario > 7)
            {
                Console.WriteLine(" Número inválido. Digite novamente: ");
                opcaoUsuario = Int32.Parse(Console.ReadLine());
            }

			return opcaoUsuario;
		}
    }
}
