using System;

namespace DIO.Series
{
    class Program
    {
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static void Main(string[] args)
        {

            int opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario >= 1 && opcaoUsuario <= 12)
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
						ListarFilmes();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 7:
						InserirFilme();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 8:
						AtualizarFilme();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 9:
						ExcluirFilme();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 10:
						VisualizarFilme();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 11:
						Console.Clear();
						opcaoUsuario = ObterOpcaoUsuario();
						break;

					case 12:
						Console.WriteLine();
						Console.WriteLine("Obrigado por utilizar nossos serviços.");
						Console.WriteLine();
						Console.WriteLine("Saindo da DIO Séries e Filmes");
						Console.WriteLine();
						Environment.Exit(0);
						break;
				}
			}
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			Console.WriteLine();
			int indiceSerie = int.Parse(Console.ReadLine()) - 1;

			repositorioSerie.Exclui(indiceSerie);
			Console.Write("Série excluída. ");
			Console.WriteLine();
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			Console.WriteLine();
			int indiceSerie = int.Parse(Console.ReadLine()) - 1;

			var serie = repositorioSerie.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			Console.WriteLine();
			int indiceSerie = int.Parse(Console.ReadLine()) - 1;

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
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

			repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
			Console.Write("Série atualizada com sucesso. ");
			Console.WriteLine();
		}

        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");
			Console.WriteLine();

			var lista = repositorioSerie.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                Console.WriteLine();
				Console.WriteLine("Id: {0} - Título: {1} - Ano: {2} {3} ",  serie.retornaId() + 1, 
																			serie.retornaTitulo(), 
																			serie.retornaAno(),																																																																								
																			(excluido ? "*Excluído*" : ""));
				Console.WriteLine();
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");
			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine();
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(), 
										genero: (Genero)entradaGenero, 
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSerie.Insere(novaSerie);
			Console.WriteLine();
			Console.Write("Série adicionada com sucesso. ");
			Console.WriteLine();
		}

 		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do Filme: ");
			Console.WriteLine();
			int indiceFilme = int.Parse(Console.ReadLine()) - 1;

			repositorioFilme.Exclui(indiceFilme);
			Console.Write("Filme excluído. ");
			Console.WriteLine();
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			Console.WriteLine();
			int indiceFilme = int.Parse(Console.ReadLine()) - 1;

			var filme = repositorioFilme.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			Console.WriteLine();
			int indiceFilme = int.Parse(Console.ReadLine()) - 1;

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										    genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

			repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
			Console.Write("Filme atualizado com sucesso. ");
			Console.WriteLine();
		}

        private static void ListarFilmes()
		{
			Console.WriteLine("Listar Filmes");
			Console.WriteLine();

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Filme cadastrada.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                Console.WriteLine();
				Console.WriteLine("Id: {0} - Título: {1} - Ano: {2} {3} ",  filme.retornaId() + 1, 
																			filme.retornaTitulo(), 
																			filme.retornaAno(),																																																																								
																			(excluido ? "*Excluído*" : ""));
				Console.WriteLine();
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");
			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine();
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(), 
										genero: (Genero)entradaGenero, 
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Insere(novoFilme);
			Console.WriteLine();
			Console.Write("Filme adicionado com sucesso. ");
			Console.WriteLine();
		}
        private static int ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Seja Bem Vindo à DIO Séries. O melhor lugar para assistir suas séries e filmes favoritos!");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();

			Console.WriteLine("(1) - Listar Séries");
			Console.WriteLine("(2) - Inserir Nova Série");
			Console.WriteLine("(3) - Atualizar Série");
			Console.WriteLine("(4) - Excluir Série");
			Console.WriteLine("(5) - Visualizar Série");
			Console.WriteLine("(6) - Listar Filmes");
			Console.WriteLine("(7) - Inserir Novo Filme");
			Console.WriteLine("(8) - Atualizar Filme");
			Console.WriteLine("(9) - Excluir Filme");
			Console.WriteLine("(10) - Visualizar Filme");
			Console.WriteLine();
			Console.WriteLine("(11) - Limpar Tela");
			Console.WriteLine("(12) - Sair (Exit)");
			Console.WriteLine();

			int opcaoUsuario = Int32.Parse(Console.ReadLine());
			Console.WriteLine();

			while (opcaoUsuario < 1 || opcaoUsuario > 12)
            {
                Console.WriteLine("Número inválido. Digite novamente: ");
                opcaoUsuario = Int32.Parse(Console.ReadLine());
            }

			return opcaoUsuario;			
		}
    }
}
