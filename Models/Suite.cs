namespace SistemaHospedagem.Models
{
    public class Suite : TelaMenu
    {
        private Dictionary<int, List<string>> _listarSuites = new Dictionary<int, List<string>>();
        private List<string> _detalhesSuite = new List<string>();
        private string _tipoSuite = " ";
        private int _capacidade;
        private decimal _valorDiaria;

        public string TipoSuite
        {
            get { return _tipoSuite; }
            set { _tipoSuite = value; }
        }

        public int Capacidade
        {
            get { return _capacidade; }
            set { _capacidade = value; }
        }

        public decimal ValorDiaria
        {
            get { return _valorDiaria; }
            set { _valorDiaria = value; }
        }

// METODO PARA DETERMINAR A CAPACIDADE DE CADA SUITE
        public void DefinirCapacidade()
        {
            do
            {
                Capacidade = 0;
                Console.WriteLine("Qual é a capacidade da suíte?");
                int.TryParse(Console.ReadLine(), out int capacidade);


                if (capacidade > 0)
                {
                    Capacidade = capacidade;

                }
                else
                {
                    Console.WriteLine("A capcidade não pode ser menor que uma pessoa");
                }
            } while (Capacidade == 0);

            _detalhesSuite.Add(Capacidade.ToString());

        }
        // METODO PARA DETERMINAR O VALOR DA DIÁRIA DE CADA SUITE
        public void DefinirValorDiaria()
        {
            Console.WriteLine("Qual é o valor da diária?");
            decimal.TryParse(Console.ReadLine(), out decimal diaria);
            ValorDiaria = diaria;
            _detalhesSuite.Add(ValorDiaria.ToString());
        }

        // METODO PARA CADASTRAR UMA NOVA SUITE
        public void CadastarSuites()
        {
            bool sair = false;
            int id = 1;
            do
            {
                MenuOpcoesSuite();
                Console.WriteLine("Escolha uma das opções acima: ");
                int.TryParse(Console.ReadLine(), out int opcao);

                switch (opcao)
                {
                    case 1:
                        TipoSuite = "Básica";
                        break;
                    case 2:
                        TipoSuite = "Duas Camas de Solteiro";
                        break;
                    case 3:
                        TipoSuite = "Casal King Size";
                        break;
                    case 4:
                        TipoSuite = "Premium";
                        break;
                    case 5:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida: ");
                        return;
                }

                if (opcao != 5)
                {
                    _detalhesSuite.Clear();
                    _detalhesSuite.Add(TipoSuite);
                    DefinirCapacidade();
                    DefinirValorDiaria();

                    bool adicionar = false;
                    do
                    {
                        if (!_listarSuites.ContainsKey(id))
                        {
                            _listarSuites[id] = new List<string>();
                            adicionar = true;
                        }
                        else
                        {
                            id++;
                        }
                    } while (!adicionar);
                    _listarSuites[id].AddRange(_detalhesSuite);


                    string resposta = "";

                    do
                    {
                        Console.WriteLine("Deseja cadastrar outra suite? S/N ");
                        resposta = Console.ReadLine().ToUpper();

                        if (resposta != "S" && resposta != "N")
                        {
                            Console.WriteLine("Opção Inválida. Digite 'S' para SIM ou 'N' para NÃO.");
                        }

                        if (resposta == "N")
                        {
                            sair = true;
                        }


                    } while (resposta != "S" && resposta != "N");

                }

                Console.Clear();

            } while (!sair);
        }


        public void ListarSuites()
        {
            Cabeçalho("LISTA DE SUITES");

            foreach (var suite in _listarSuites)
            {
                Console.WriteLine($"\n          ID {suite.Key}");
        
                for (int i = 0; i < suite.Value.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine($"          Tipo: {suite.Value[i]}");
                            break;
                        case 1:
                            Console.WriteLine($"          Capacidade: {suite.Value[i]} pessoas");
                            break;
                        case 2:
                            if (decimal.TryParse(suite.Value[i] as string, out decimal valorDiaria))
                            {
                                Console.WriteLine($"          Valor da diária: {valorDiaria:C}");
                            }
                            break;
                        case 3 :
                            if (suite.Value[i].Equals("Reservada"))
                            {
                                Console.WriteLine("          A suite está reservada");
                            }
                            break;
                    }
                }
            }
        }


        public void ReservarSuite()
        {
            Reserva hospedeReserva = new Reserva();
            int vagas = 0;
            ListarSuites();
            Console.WriteLine("Escolha uma das suites desocupadas para reservar: (Digite o ID) ");
            int.TryParse(Console.ReadLine(), out int reserva);
            
            
            foreach (var reservada in _listarSuites)
            {
                if (reservada.Key == reserva)
                {
                    int.TryParse(reservada.Value[1], out vagas);
                    reservada.Value.Add("Reservada");
                }
            }
            
            Console.WriteLine($"A suite tem espaço para {vagas} pessoas: ");
            ListarHospedes();
            Console.WriteLine("Escolha o ID do hóspede que fará a reserva. ");
            int.TryParse(Console.ReadLine(), out int hospede);
            foreach (var item in _listar)
            {
                if (item.Key == hospede)
                {
                    foreach (var pessoa in item.Value)
                    {
                        pessoa.Hospedado = $"- Hospedado na suite {reserva}";
                    }
                }
            }
            
        }
    }

}
