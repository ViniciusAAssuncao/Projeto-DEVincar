using System.Globalization;
using System.Text.RegularExpressions;

namespace DEVinCar;

public class Veiculo {
    public string Cpf = "0";
    public Historico Historico = new();
    public string Chassi { get; set; }
    public DateOnly DataFabricacao { get; set; }
    public string Nome { get; set; }
    public string Placa { get; set; }
    public double Valor { get; set; }
    public string Cor { get; set; }

    public static string alfanumericoAleatorio(int tamanho) {
        var alfanumerico = "";
        var caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var rnd = new Random();
        for (var i = 0; i < tamanho; i++) alfanumerico += caracteres[rnd.Next(0, caracteres.Length)];
        return alfanumerico;
    }

    public void VenderVeiculo() {
        var regex = @"^\d{3}.?\d{3}.?\d{3}-?\d{2}$";
        Console.WriteLine("Vender veículo: ");
        Console.WriteLine("Digite o CPF do cliente");
        Cpf = Console.ReadLine();
        var cpfValidator = new Regex(regex);
        if (!cpfValidator.IsMatch(Cpf)) throw new Exception("CPF inválido");
        Console.WriteLine("CPF válido");
        Console.WriteLine("Digite o valor da venda");
        Historico.Preco = double.Parse(Console.ReadLine());
        Historico.Cpf = Cpf;
        Historico.Data = DateTime.Now;
    }

    public void ListarInformacoes() {
        Console.WriteLine("");
        Console.WriteLine("Listando as informações cadastradas: ");
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Placa: " + Placa);
        Console.WriteLine("Chassi: " + Chassi);
        Console.WriteLine("Data de fabricação: " + DataFabricacao);
        Console.WriteLine("Valor: R$ " + Valor.ToString("F2", CultureInfo.InvariantCulture));
        Console.WriteLine("Cor: " + Cor);
        if (Cpf != "0") {
            Console.WriteLine("CPF: " + Historico.Cpf);
            Console.WriteLine("Data da compra: " + Historico.Data);
            Console.WriteLine("Valor da compra: " + Historico.Preco.ToString("F2", CultureInfo.InvariantCulture));
        }
    }

    public void AlterarInformacoes() {
        Console.WriteLine("");
        Console.WriteLine("Alterando as informações cadastradas: ");
        Console.WriteLine("Digite o novo nome: ");
        Nome = Console.ReadLine();
        Console.WriteLine("Digite a nova cor: ");
        Cor = Console.ReadLine();
        Console.WriteLine("Digite o novo valor: ");
        Valor = Convert.ToDouble(Console.ReadLine());
    }
}