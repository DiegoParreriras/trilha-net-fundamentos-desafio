using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {   // Coloquei tryCatch, apenas pq vi que algumas entradas encerram o programa ,apertar o enter em alguns momentos encerra o programa.
        case "1":try{
            es.AdicionarVeiculo();
              }catch(Exception ex){
            Console.WriteLine("Ocorereu um erro inesperado - "+ex.Message);
        }
            break;

        case "2":try{
            es.RemoverVeiculo();
             }catch(Exception ex){
            Console.WriteLine("Ocorereu um erro inesperado - "+ex.Message);
        }
            break;

        case "3":try{
            es.ListarVeiculos();
             }catch(Exception ex){
            Console.WriteLine("Ocorereu um erro inesperado - "+ex.Message);
        }
            break;

        case "4":try{
            exibirMenu = false;
             }catch(Exception ex){
            Console.WriteLine("Ocorereu um erro inesperado - "+ex.Message);
        }
            break;

        default:try{
            Console.WriteLine("Opção inválida");
             }catch(Exception ex){
            Console.WriteLine("Ocorereu um erro inesperado - "+ex.Message);
        }
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
