namespace SistemaHospedagem.Models
{
    public class Reserva
    {
        // Dicionário para armazenar os hóspedes, utilizando um ID único como chave
        private Dictionary<int, List<Pessoa>> _listandoHospedes = new Dictionary<int, List<Pessoa>>();
        
       
        // Variável para armazenar o número de dias reservados
        private int _diasReservados;

        // Propriedade para acessar o dicionário de suítes por tipo
       

        // Propriedade para acessar o dicionário de hóspedes
        public Dictionary<int, List<Pessoa>> ListandoHospedes
        {
            get
            {
                return _listandoHospedes;
            }
        }

        // Método para cadastrar hóspedes
        public void CadastrarHospedes()
        {
            int id = 0;
            string cont;
    
            do
            {
                id++;
                Pessoa hospede = new Pessoa();
                Console.WriteLine("Digite o nome do hóspede: ");
                hospede.Nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome: ");
                hospede.Sobrenome = Console.ReadLine();
        
                // Verifica se a chave já existe no dicionário, senão, adiciona uma nova lista vazia
                bool adicionar = false;
                do
                {
                    if (!_listandoHospedes.ContainsKey(id))
                    {
                        _listandoHospedes[id] = new List<Pessoa>();
                        adicionar = true;
                    }
                    else
                    {
                        id++;
                    }
                } while (!adicionar);

                // Adiciona o hóspede à lista correspondente
                _listandoHospedes[id].Add(hospede);
        
                do
                {
                    Console.WriteLine("Deseja cadastrar mais um hóspede? S/N ");
                    cont = Console.ReadLine().ToUpper();
                    if (cont != "S" && cont != "N")
                    {
                        Console.WriteLine("Opção inválida!" +
                                          "\n Digite S ou N");
                    }
                } while (cont != "S" && cont != "N" );

            } while (cont != "N");
        }

        
        public decimal CalcularValorDiária()
        {
            Suite<decimal> _suite = new Suite<decimal>();
            if (_listandoHospedes.Count < 10)
            {
                return _diasReservados * _suite.ValorDiaria;
            }
            else
            {
                return ((_diasReservados * _suite.ValorDiaria) / 100) * 90;
            }
        }
        
    } // Fim da classe Reserva
} 