namespace SistemaHospedagem.Models
{
    // Classe responsável por apresentar o menu de opções ao usuário
    public class TelaMenu
    { 
        private static Reserva _cadastro = new Reserva();
        
        
        
        // Dicionário que armazena a lista de hóspedes da reserva
        public Dictionary<int, List<Pessoa>> _listar = _cadastro.ListandoHospedes;
        
        private void TelaPrincipal()
        {
            Console.WriteLine("____________________________________________________________________" +
                              "\n           " +
                              "\n        ### SISTEMA DE CADASTROS E RESERVAS - HOTEL ROYAL ###            " +
                              "\n____________________________________________________________________" +
                              "\n " +
                              "\n                          ** OPÇÕES **" +
                              "\n" +
                              "\n                      1. Cadastrar Suite" +
                              "\n                      2. Cadastrar Hospede" +
                              "\n                      3. Reservar Suite" +
                              "\n                      4. Listar Hospedes" +
                              "\n                      5. Listar Suites" +
                              "\n                      6. Sair" + 
                              "\n___________________________________________________________________\n");
        }

       // Método responsável por apresentar as opções do menu ao usuário e executar a ação correspondente
        public void MenuOpcpes()
        {
            bool sair = false;
            Suite suite = new Suite();
            do
            {
                Console.Clear();
                TelaPrincipal();
                Console.WriteLine("Digite o número da opção escolhida: ");
                int.TryParse(Console.ReadLine(), out int opcao);
        
                // Switch case para executar a ação conforme a escolha do usuário
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        suite.CadastarSuites();
                        break;
                    case 2:
                        Console.Clear();
                        _cadastro.CadastrarHospedes();
                        break;
                    case 3:
                        Console.Clear();
                        suite.ReservarSuite();
                        LimparTela();
                        break;
                    case 4:
                        Console.Clear();
                        ListarHospedes();
                        LimparTela();
                        break;
                    case 5:
                        Console.Clear();
                        suite.ListarSuites();
                        LimparTela();
                        break;
                    case 6:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida! ");
                        break;
                }
            }while (!sair);
        }

        
        // Método responsável por apresentar as opções de cadastro de suites ao usuário
        public void MenuOpcoesSuite()
        {
            Console.WriteLine("____________________________________________________________________" +
                              "\n           " +
                              "\n        ### Qual tipo de suite que você deseja cadastar? ###            " +
                              "\n____________________________________________________________________" +
                              "\n " +
                              "\n                          ** OPÇÕES **" +
                              "\n" +
                              "\n                      1. Suite Básica" +
                              "\n                      2. Suite Duas Camas de Solteiro" +
                              "\n                      3. Suite Casal King Size" +
                              "\n                      4. Suite Premium" +
                              "\n                      5. Sair" +
                              "\n___________________________________________________________________\n");
        }

        public void Cabeçalho(string texto)
        {
            Console.WriteLine("____________________________________________________________________" +
                              "\n           " +
                              $"\n                     ### {texto} ###            " +
                              "\n____________________________________________________________________");
        }

        // Método responsável por limpar a tela do console
        public void LimparTela()
        {
            Console.WriteLine("\nAperte qualquer tecla para continuar: ");
            Console.ReadLine();
            Console.Clear();
        }

        // Método responsável por listar os hóspedes cadastrados na reserva
        public void ListarHospedes()
        {
            Cabeçalho("LISTA DE HÓSPEDES");
            foreach (var hospede in _listar)
            {
                foreach (var pessoa in hospede.Value)
                {
                    Console.WriteLine($"\n              ID {hospede.Key}. Nome: {pessoa.Nome} {pessoa.Sobrenome} {(pessoa.Hospedado != "Não" ? pessoa.Hospedado : "")}");
                }
            }
            Console.WriteLine("___________________________________________________________________\n");
        }
    }
}
