namespace SistemaHospedagem.Models
{
    public class Suite<T> : TelaMenu
    {
        private Dictionary<int, List<T>> _listarSuites = new Dictionary<int, List<T>>();
        private List<T> _detalhesSuite = new List<T>();
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

            _detalhesSuite.Add((T)Convert.ChangeType(Capacidade, typeof(T)));

        }

        public void DefinirValorDiaria()
        {
            Console.WriteLine("Qual é o valor da diária?");
            decimal.TryParse(Console.ReadLine(), out decimal diaria);
            ValorDiaria = diaria;
            _detalhesSuite.Add((T)Convert.ChangeType(ValorDiaria, typeof(T)));
        }

        public void CadastarSuites()
        {
            bool sair = false;
            int id = 0; // Inicializar a variável id
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
                    _detalhesSuite.Add((T)Convert.ChangeType(TipoSuite, typeof(T)));
                    DefinirCapacidade();
                    DefinirValorDiaria();

                    id++;
                    _listarSuites[id] = new List<T>();
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
            int cont = 0;
            Console.WriteLine("____________________________________________________________________" +
                              "\n           " +
                              "\n                     ### LISTA DE SUITE ###            " +
                              "\n____________________________________________________________________");
            foreach (var suites in _listarSuites)
            {
                Console.WriteLine($"\nID {suites.Key}");
                do
                {
                    switch (cont)
                    {
                        case 0:
                            Console.WriteLine($"Tipo: {suites.Value[cont]}");
                            cont++;
                            break;
                        case 1:
                            Console.WriteLine($"Capacidade: {suites.Value[cont]} pessoas");
                            cont++;
                            break;
                        case 2:
                            Console.WriteLine($"Valor da diária: {suites.Value[cont]}");
                            cont = 0;
                            break;
                    }
                }while(cont !=0);

            }


        }
    }

}
