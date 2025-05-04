namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        // Listas para armazenar letras e números para a validação da placa modelo antigo
        List<string> letters = [ "A", "B", "C", "D", "E", "F", "G",
                                "H", "I", "J", "K", "L", "M", "N",
                                "O", "P", "Q", "R", "S", "T", "U",
                                "V", "W", "X", "Y", "Z"];

        List<string> numbers = ["1","2","3","4","5","6","7","8","9","0"];
        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar(Ex: AAA-1111):");
            string carro = Console.ReadLine();
            string pattern = @"^[A-Za-z]{3}-\d{4}";
            
            if(System.Text.RegularExpressions.Regex.IsMatch(carro,pattern))
            {
                //variaveis para gerar subStrings, pegando os valores das letras e numeros 
                string lettersCar = carro[..3];
                string numbersCar = carro[4..];

                // contadores para validar a placa
                int countLetters = 0;
                int countNumbers = 0;
                for(int i = 0; i < lettersCar.Length; i++)
                {
                    if(letters.Contains(lettersCar[i].ToString().ToUpper()))
                    {
                        countLetters++;
                    }
                }

                for(int i =0; i < numbersCar.Length; i++)
                {
                    if(numbers.Contains(numbersCar[i].ToString()))
                    {
                        countNumbers++;
                    }
                }
                    if(countLetters==3 && countNumbers==4)
                    {
                        veiculos.Add(carro);
                        Console.WriteLine("Carro cadastrado com sucesso!");
                    }else
                    {
                        Console.WriteLine("Placa invalida, use o padrão AAA-1111");
                    }                

            }else
            {
                Console.WriteLine("Placa invalida, use o padrão AAA-1111");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoInicial * horas; 

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                for (int i = 0; i < veiculos.Count; i++)
                {
                    if(veiculos[i].ToUpper() == placa.ToUpper())
                    {
                        veiculos.RemoveAt(i);
                    }else
                    {
                        Console.WriteLine("Placa não encontrada");
                    }
                }
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                int count = 1 ;
                foreach(string car in veiculos)
                {
                    Console.WriteLine($"{count} - {car.ToUpper()}");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
