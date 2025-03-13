class KodeProduk { 
    private string[] produkElektronik = { "Laptop", "Smartphone", "Tablet", "Headset", "Keyboard", "Mouse", "Printer", "Monitor", "Smartwatch", "Kamera" };
    private string[] kodeProduk = { "E100", "E101", "E102", "E103", "E104", "E105", "E106", "E107", "E108", "E109" };

    public string getKodeProduk(string produk)
    {
        for (int i = 0; i < produkElektronik.Length; i++)
        {
            if (produkElektronik[i] == produk)
            {
                return kodeProduk[i];
            }
        }
        return "Produk tidak ditemukan";
    }
}

class Program
{
    static void Main(string[] args)
    {
        KodeProduk kodeProduk = new KodeProduk();
        string kodeProdukVar = Console.ReadLine();
        Console.WriteLine(kodeProduk.getKodeProduk(kodeProdukVar));
    }
}