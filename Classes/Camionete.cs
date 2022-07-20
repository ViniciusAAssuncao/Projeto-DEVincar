namespace DEVinCar;

public class Camionete : Veiculo {
    public double CapacidadeCarga;
    public string Combustivel;
    public int Portas;
    public int Potencia;

    public Camionete(int portas, int potencia, double capacidadeCarga, string combustivel) {
        Portas = portas;
        Potencia = potencia;
        CapacidadeCarga = capacidadeCarga;
        Combustivel = combustivel;
        Chassi = alfanumericoAleatorio(17);
        Placa = alfanumericoAleatorio(7);
    }

    public void ListarCamionete() {
        ListarInformacoes();
        Console.WriteLine("Portas: " + Portas);
        Console.WriteLine("Potencia: " + Potencia + " cavalos");
        Console.WriteLine("Capacidade de carga: " + CapacidadeCarga + " litros");
        Console.WriteLine("Combustivel: " + Combustivel);
    }
}