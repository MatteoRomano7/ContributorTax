using System;

class Contribuente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime DataNascita { get; set; }
    public string CodiceFiscale { get; set; }
    public char Sesso { get; set; }
    public string ComuneResidenza { get; set; }
    public decimal RedditoAnnuale { get; set; }

    public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, decimal redditoAnnuale)
    {
        Nome = nome;
        Cognome = cognome;
        DataNascita = dataNascita;
        CodiceFiscale = codiceFiscale;
        Sesso = sesso;
        ComuneResidenza = comuneResidenza;
        RedditoAnnuale = redditoAnnuale;
    }

    public Contribuente()
    {
        // Costruttore vuoto
    }

    public void CalcolaImposta()
    {
        decimal imposta = 0;

        if (RedditoAnnuale <= 15000)
        {
            imposta = RedditoAnnuale * 0.23m;
        }
        else if (RedditoAnnuale <= 28000)
        {
            imposta = 3450 + (RedditoAnnuale - 15000) * 0.27m;
        }
        else if (RedditoAnnuale <= 55000)
        {
            imposta = 6960 + (RedditoAnnuale - 28000) * 0.38m;
        }
        else if (RedditoAnnuale <= 75000)
        {
            imposta = 17220 + (RedditoAnnuale - 55000) * 0.41m;
        }
        else
        {
            imposta = 25420 + (RedditoAnnuale - 75000) * 0.43m;
        }

        Console.WriteLine($"============================================");
        Console.WriteLine($"CALCOLO DELL'IMPOSTA DA VERSARE:");
        Console.WriteLine($"Contribuente: {Nome} {Cognome},");
        Console.WriteLine($"nato il {DataNascita:dd/MM/yyyy} ({Sesso}),");
        Console.WriteLine($"residente in {ComuneResidenza},");
        Console.WriteLine($"codice fiscale: {CodiceFiscale}");
        Console.WriteLine($"Reddito dichiarato: € {RedditoAnnuale:N2}");
        Console.WriteLine($"IMPOSTA DA VERSARE: € {imposta:N2}");
        Console.WriteLine($"============================================");
    }
}

class Program
{
    static void Main()
    {
        Contribuente contribuente = new Contribuente();

        Console.Write("Inserisci il nome del contribuente: ");
        contribuente.Nome = Console.ReadLine();

        Console.Write("Inserisci il cognome del contribuente: ");
        contribuente.Cognome = Console.ReadLine();

        Console.Write("Inserisci la data di nascita del contribuente (formato dd/MM/yyyy): ");
        contribuente.DataNascita = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Inserisci il codice fiscale del contribuente: ");
        contribuente.CodiceFiscale = Console.ReadLine();

        Console.Write("Inserisci il sesso del contribuente (M/F): ");
        contribuente.Sesso = char.Parse(Console.ReadLine());

        Console.Write("Inserisci il comune di residenza del contribuente: ");
        contribuente.ComuneResidenza = Console.ReadLine();

        Console.Write("Inserisci il reddito annuale del contribuente: ");
        contribuente.RedditoAnnuale = decimal.Parse(Console.ReadLine());

        contribuente.CalcolaImposta();
    }
}
