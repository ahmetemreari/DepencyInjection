using Microsoft.Extensions.DependencyInjection;
using System;


// IOgretmen arayüzü
public interface IOgretmen
{
    string BilgiGetir();
}

// Ogretmen sınıfı
public class Ogretmen : IOgretmen
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
//öğretmen için staatic data
    public Ogretmen()
    {
           Ad = "Ahmet";
        Soyad = "Yılmaz";
    }

//öğretmen bilgi çekme
    public string BilgiGetir()
    {
        return $"Öğretmen: {Ad} {Soyad}";
    }
}

// Sınıf
public class Sinif
{
    private readonly IOgretmen _ogretmen;

    
    public Sinif(IOgretmen ogretmen)
    {
        _ogretmen = ogretmen;
    }
//öğretmen bilgisi getirme
    public string OgretmenBilgisiGetir()
    {
        return _ogretmen.BilgiGetir();
    }
}

// Program classı
class Program
{
    static void Main(string[] args)
    {
        // ÖÇğretmen bilgisi çekip yazdırma
        var servisSaglayici = new ServiceCollection()
            .AddSingleton<IOgretmen, Ogretmen>()
            .BuildServiceProvider();

        var ogretmen = servisSaglayici.GetService<IOgretmen>();
        var sinif = new Sinif(ogretmen);

        Console.WriteLine(sinif.OgretmenBilgisiGetir());
    }
}