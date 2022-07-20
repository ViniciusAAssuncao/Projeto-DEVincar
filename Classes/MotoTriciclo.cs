namespace DEVinCar;

public class MotoTriciclo : Veiculo {
    public int Potencia;
    public int Rodas;

    public MotoTriciclo(int potencia, int rodas = 2) {
        Potencia = potencia;
        Rodas = rodas;
        Chassi = alfanumericoAleatorio(17);
        Placa = alfanumericoAleatorio(7);
    }

    public void ListarMotoTriciclo() {
        ListarInformacoes();
        Console.WriteLine("Rodas: " + Rodas);
        Console.WriteLine("Potencia: " + Potencia + " cavalos");
    }
}