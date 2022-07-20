namespace DEVinCar;

public class Carro : Veiculo {
    public string IsFlex;
    public int Portas;
    public int Potencia;

    public Carro(int potencia, int portas, string combustivel) {
        Portas = portas;
        Potencia = potencia;
        IsFlex = combustivel;
        Chassi = alfanumericoAleatorio(17);
        Placa = alfanumericoAleatorio(7);
    }

    public void ListarCarro() {
        ListarInformacoes();
        Console.WriteLine("Portas: " + Portas);
        Console.WriteLine("Potencia: " + Potencia + " cavalos");
        Console.WriteLine("Combustivel: " + IsFlex);
    }
}