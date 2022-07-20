namespace DEVinCar;

internal class Program {
    private static void Main(string[] args) {
        var listaMotoTriciclos = new List<MotoTriciclo>();
        var listaCarro = new List<Carro>();
        var listaCamionete = new List<Camionete>();
        MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
    }

    private static void MostraMenu(List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        var opcao = 0;
        Console.WriteLine("Seja bem-vindo ao DEVincar!");
        Console.WriteLine("1 - Cadastrar veículo");
        Console.WriteLine("2 - Listar todos os veículos");
        Console.WriteLine("3 - Carros disponíveis ('Somente veículos não vendidos')");
        Console.WriteLine("4 - Editar veículos ('Somente veículos não vendidos')");
        Console.WriteLine("5 - Carros vendidos");
        Console.WriteLine("6 - Carro vendido com o maior preço");
        Console.WriteLine("7 - Carro vendido com o menor preço");
        opcao = int.Parse(Console.ReadLine());

        switch (opcao) {
            case 1:
                Console.WriteLine("Qual veículo você deseja cadastrar? Digite 1 para Moto/Triciclo, 2 para Carro, " +
                                  "3 para Camionete");
                opcao = int.Parse(Console.ReadLine());
                MenuCadastro(opcao, listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 2:
                Console.WriteLine("Escolha qual tipo de veículo você deseja listar: ");
                Console.WriteLine("1 - Motos/Triciclos");
                Console.WriteLine("2 - Carros");
                Console.WriteLine("3 - Camionetes");
                Console.WriteLine("4 - Todos");
                opcao = int.Parse(Console.ReadLine());
                ListarTodos(opcao, listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 3:
                ListarDisponiveis(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 4:
                EditarVeiculos(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 5:
                ListarVendidos(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 6:
                MaiorPreco(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 7:
                MenorPreco(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            default:
                MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
        }
    }

    private static void ListarTodos(int opcao, List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        if (listaMotoTriciclos.Count <= 0 || listaCarro.Count <= 0 || listaCamionete.Count <= 0)
            Console.WriteLine("Não há nada aqui :(");
        if (opcao == 1) {
            foreach (var motoTriciclo in listaMotoTriciclos) motoTriciclo.ListarMotoTriciclo();
        }
        else if (opcao == 2) {
            foreach (var carro in listaCarro) carro.ListarCarro();
        }
        else if (opcao == 3) {
            foreach (var camionete in listaCamionete) camionete.ListarCamionete();
        }
        else if (opcao == 4) {
            foreach (var motoTriciclo in listaMotoTriciclos) motoTriciclo.ListarMotoTriciclo();
            foreach (var carro in listaCarro) carro.ListarCarro();
            foreach (var camionete in listaCamionete) camionete.ListarCamionete();
        }
        else {
            throw new Exception("O usuário digitou uma opção inválida");
        }

        MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
    }

    private static void EditarVeiculos(List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        string placa;
        if (listaMotoTriciclos.Count <= 0 || listaCarro.Count <= 0 || listaCamionete.Count <= 0) 
        {
            Console.WriteLine("Não há nada aqui :(");
            MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
        }

        foreach (var motoTriciclo in listaMotoTriciclos)
            if (motoTriciclo.Cpf == "0") {
                motoTriciclo.ListarMotoTriciclo();
            }

        foreach (var carro in listaCarro)
            if (carro.Cpf == "0") {
                carro.ListarCarro();
            }

        foreach (var camionete in listaCamionete)
            if (camionete.Cpf == "0") {
                camionete.ListarCamionete();
            }
        Console.WriteLine("Digite a placa do veículo que deseja editar: ");
        placa = Console.ReadLine();
        placa = placa.ToUpper();
        foreach (var motoTriciclo in listaMotoTriciclos)
            if (motoTriciclo.Placa == placa) {
                motoTriciclo.AlterarInformacoes();
            }

        foreach (var carro in listaCarro) {
            if (carro.Placa == placa) {
                carro.AlterarInformacoes();
            }
        }
        foreach (var camionete in listaCamionete) {
            if (camionete.Placa == placa) {
                camionete.AlterarInformacoes();
            }
        }
        MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
    }

    private static void ListarDisponiveis(List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        string opcao, placa;
        if (listaMotoTriciclos.Count <= 0 || listaCarro.Count <= 0 || listaCamionete.Count <= 0)
            Console.WriteLine("Não há nada aqui :(");
        foreach (var motoTriciclo in listaMotoTriciclos)
            if (motoTriciclo.Cpf == "0")
                motoTriciclo.ListarMotoTriciclo();
        foreach (var carro in listaCarro)
            if (carro.Cpf == "0")
                carro.ListarCarro();
        foreach (var camionete in listaCamionete)
            if (camionete.Cpf == "0")
                camionete.ListarCamionete();
        Console.WriteLine("Você deseja comprar algum destes veículos?");
        opcao = Console.ReadLine().ToLower();
        opcao = char.ToUpper(opcao[0]) + opcao.Substring(1);
        if (opcao == "Sim") {
            Console.WriteLine("Digite a placa do veículo que você deseja comprar");
            placa = Console.ReadLine();
            placa = placa.ToUpper();
            foreach (var motoTriciclo in listaMotoTriciclos)
                if (motoTriciclo.Placa == placa && motoTriciclo.Cpf == "0")
                    motoTriciclo.VenderVeiculo();
            foreach (var carro in listaCarro)
                if (carro.Placa == placa && carro.Cpf == "0")
                    carro.VenderVeiculo();
            foreach (var camionete in listaCamionete)
                if (camionete.Placa == placa && camionete.Cpf == "0")
                    camionete.VenderVeiculo();
        }
        else {
            Console.WriteLine("Ok, então não vamos comprar nada");
        }

        MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
    }

    private static void ListarVendidos(List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        if (listaMotoTriciclos.Count <= 0 || listaCarro.Count <= 0 || listaCamionete.Count <= 0)
            Console.WriteLine("Não há nada aqui :(");
        foreach (var motoTriciclo in listaMotoTriciclos)
            if (motoTriciclo.Cpf != "0")
                motoTriciclo.ListarMotoTriciclo();
        foreach (var carro in listaCarro)
            if (carro.Cpf != "0")
                carro.ListarCarro();
        foreach (var camionete in listaCamionete)
            if (camionete.Cpf != "0")
                camionete.ListarCamionete();
        MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
    }

    private static void MaiorPreco(List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        if (listaMotoTriciclos.Count <= 0 || listaCarro.Count <= 0 || listaCamionete.Count <= 0)
            Console.WriteLine("Não há nada aqui :(");
        listaMotoTriciclos.Sort((x, y) => x.Historico.Preco.CompareTo(y.Historico.Preco));
        listaCarro.Sort((x, y) => x.Historico.Preco.CompareTo(y.Historico.Preco));
        listaCamionete.Sort((x, y) => x.Historico.Preco.CompareTo(y.Historico.Preco));
        Console.WriteLine("O veículo mais caro é: ");
        if (listaMotoTriciclos.Count > 0)
            listaMotoTriciclos[listaMotoTriciclos.Count - 1].ListarMotoTriciclo();
        else if (listaCarro.Count > 0)
            listaCarro[listaCarro.Count - 1].ListarCarro();
        else if (listaCamionete.Count > 0)
            listaCamionete[listaCamionete.Count - 1].ListarCamionete();
        else
            Console.WriteLine("Não há nada aqui :(");
        MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
    }

    private static void MenorPreco(List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        listaMotoTriciclos.Sort((x, y) => x.Historico.Preco.CompareTo(y.Historico.Preco));
        listaCarro.Sort((x, y) => x.Historico.Preco.CompareTo(y.Historico.Preco));
        listaCamionete.Sort((x, y) => x.Historico.Preco.CompareTo(y.Historico.Preco));
        Console.WriteLine("O veículo com o menor preço é: ");
        if (listaMotoTriciclos.Count > 0 && listaMotoTriciclos[0].Historico.Preco != 0)
            listaMotoTriciclos[0].ListarMotoTriciclo();
        else if (listaCarro.Count > 0 && listaCarro[0].Historico.Preco != 0)
            listaCarro[0].ListarCarro();
        else if (listaCamionete.Count > 0 && listaCamionete[0].Historico.Preco != 0)
            listaCamionete[0].ListarCamionete();
        else
            Console.WriteLine("Não há nada aqui :(");
        MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
    }

    private static void MenuCadastro(int opcao, List<MotoTriciclo> listaMotoTriciclos, List<Carro> listaCarro,
        List<Camionete> listaCamionete) {
        switch (opcao) {
            case 1:
                CadastraMotoTriciclo(listaMotoTriciclos);
                MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 2:
                CadastraCarro(listaCarro);
                MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            case 3:
                CadastraCamionete(listaCamionete);
                MostraMenu(listaMotoTriciclos, listaCarro, listaCamionete);
                break;
            default:
                throw new Exception("O usuário digitou uma opção inválida");
        }
    }

    private static void CadastraMotoTriciclo(List<MotoTriciclo> listaMotoTriciclos) {
        int potencia, dia, mes, ano, opcao = 0;
        string nome, cor, IsFlex = "";
        double valor, capacidadeCarga = 0;
        Console.WriteLine("Digite quantas rodas você deseja: 2 para moto, 3 para triciclo");
        var rodas = int.Parse(Console.ReadLine());
        if (rodas == 2) {
            Console.WriteLine("Digite o nome da moto que você está cadastrando: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o dia em que esta moto foi fabricada: ");
            dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o mês em que esta moto foi fabricada: ");
            mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ano em que esta moto foi fabricada: ");
            ano = int.Parse(Console.ReadLine());
            if (ano == DateTime.Now.Year)
                if (mes > DateTime.Now.Month && dia > DateTime.Now.Day)
                    throw new Exception("O veículo não pode ter sido fabricado em uma data inexistente");
            if (ano > DateTime.Now.Year)
                throw new Exception("O veículo não pode ter sido fabricado em uma data inexistente");
            Console.WriteLine("Digite o valor da moto que você está cadastrando: ");
            valor = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a potência do motor: ");
            potencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a cor da moto que você está cadastrando: ");
            cor = Console.ReadLine();
            var moto = new MotoTriciclo(potencia, rodas);
            moto.Nome = nome;
            moto.Cor = cor;
            moto.Valor = valor;
            moto.DataFabricacao = new DateOnly(ano, mes, dia);
            listaMotoTriciclos.Add(moto);
            moto.ListarMotoTriciclo();
        }
        else if (rodas == 3) {
            Console.WriteLine("Digite o nome do triciclo que você está cadastrando: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o dia em que este triciclo foi fabricado: ");
            dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o mês em que este triciclo foi fabricado: ");
            mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ano em que este triciclo foi fabricado: ");
            ano = int.Parse(Console.ReadLine());
            if (dia > DateTime.Now.Day && mes > DateTime.Now.Month && ano > DateTime.Now.Year)
                throw new Exception("O veículo não pode ter sido fabricado em uma data inexistente");
            Console.WriteLine("Digite o valor do triciclo que você está cadastrando: ");
            valor = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a potência do motor: ");
            potencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a cor do triciclo que você está cadastrando: ");
            cor = Console.ReadLine();
            var triciclo = new MotoTriciclo(potencia, rodas);
            triciclo.Nome = nome;
            triciclo.Cor = cor;
            triciclo.Valor = valor;
            triciclo.DataFabricacao = new DateOnly(ano, mes, dia);
            listaMotoTriciclos.Add(triciclo);
            triciclo.ListarMotoTriciclo();
        }
        else {
            Console.WriteLine("Digite uma opção válida");
        }
    }

    private static void CadastraCarro(List<Carro> listaCarro) {
        int potencia, portas, dia, mes, ano, opcao = 0;
        string nome, cor, combustivel, IsFlex = "";
        double valor, capacidadeCarga = 0;
        Console.WriteLine("Digite o nome do carro que você está cadastrando: ");
        nome = Console.ReadLine();
        Console.WriteLine("Digite o dia em que este carro foi fabricado: ");
        dia = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o mês em que este carro foi fabricado: ");
        mes = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o ano em que este carro foi fabricado: ");
        ano = int.Parse(Console.ReadLine());
        if (ano == DateTime.Now.Year)
            if (mes > DateTime.Now.Month && dia > DateTime.Now.Day)
                throw new Exception("O veículo não pode ter sido fabricado em uma data inexistente");
        if (ano > DateTime.Now.Year)
            throw new Exception("O veículo não pode ter sido fabricado em uma data inexistente");
        Console.WriteLine("Digite a cor do carro que você está cadastrando: ");
        cor = Console.ReadLine();
        Console.WriteLine("Digite o valor do carro que você está cadastrando: ");
        valor = double.Parse(Console.ReadLine());
        Console.WriteLine("Digite quantas portas têm o carro: ");
        portas = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a potência do motor: ");
        potencia = int.Parse(Console.ReadLine());
        Console.WriteLine("Este carro é a gasolina ou é flex?");
        combustivel = Console.ReadLine().ToLower();
        combustivel = char.ToUpper(combustivel[0]) + combustivel.Substring(1);
        if (combustivel == "Gasolina")
            combustivel = "Gasolina";
        else if (combustivel == "Flex")
            combustivel = "Flex";
        else
            throw new Exception("O usuário digitou uma opção inválida");
        var carro = new Carro(potencia, portas, combustivel);
        carro.Nome = nome;
        carro.Cor = cor;
        carro.Valor = valor;
        carro.DataFabricacao = new DateOnly(ano, mes, dia);
        listaCarro.Add(carro);
        carro.ListarCarro();
    }

    private static void CadastraCamionete(List<Camionete> listaCamionete) {
        int potencia, portas, dia, mes, ano, opcao = 0;
        string nome, cor, combustivel;
        double valor, capacidadeCarga = 0;
        Console.WriteLine("Digite o nome da camionete que você está cadastrando: ");
        nome = Console.ReadLine();
        Console.WriteLine("Digite o dia em que esta camionete foi fabricada: ");
        dia = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o mês em que esta camionete foi fabricada: ");
        mes = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o ano em que esta camionete foi fabricada: ");
        ano = int.Parse(Console.ReadLine());
        if (ano == DateTime.Now.Year)
            if (mes > DateTime.Now.Month || dia > DateTime.Now.Day)
                throw new Exception("O veículo não pode ter sido fabricado em uma data inexistente");
        if (ano > DateTime.Now.Year)
            throw new Exception("O veículo não pode ter sido fabricado em uma data inexistente");
        Console.WriteLine("Digite o valor da camionete que você está cadastrando: ");
        valor = double.Parse(Console.ReadLine());
        Console.WriteLine(
            "Digite a cor da camionete que você está cadastrando (Lembre-se, o DEVincar só fabrica camionetes da cor roxa): ");
        cor = Console.ReadLine().ToLower();
        cor = char.ToUpper(cor[0]) + cor.Substring(1);
        if (cor == "Roxa" || cor == "Roxo" || cor == "Púrpura")
            cor = "Roxa";
        else
            throw new Exception("O usuário digitou uma opção inválida");
        Console.WriteLine("Digite quantas portas têm esta camionete: ");
        portas = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a potência do motor: ");
        potencia = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a capacidade de carga desta camionete (Em litros): ");
        capacidadeCarga = double.Parse(Console.ReadLine());
        Console.WriteLine("Esta camionete é a gasolina ou a diesel?");
        combustivel = Console.ReadLine().ToLower();
        combustivel = char.ToUpper(combustivel[0]) + combustivel.Substring(1);
        if (combustivel == "Gasolina")
            combustivel = "Gasolina";
        else if (combustivel == "Diesel")
            combustivel = "Diesel";
        else
            throw new Exception("O usuário digitou uma opção inválida");
        var camionete = new Camionete(portas, potencia, capacidadeCarga, combustivel);
        camionete.Nome = nome;
        camionete.Cor = cor;
        camionete.Valor = valor;
        camionete.DataFabricacao = new DateOnly(ano, mes, dia);
        listaCamionete.Add(camionete);
        camionete.ListarCamionete();
    }
}