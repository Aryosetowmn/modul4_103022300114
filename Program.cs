using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

class FanLaptop {
    public enum State { Quiet, Balanced, Performance, Turbo };
    public enum Trigger { ModeUp, ModeDown, TurboShortcut };
    private State currentState;
    class changeMode {
        public State stateAwal;
        public Trigger trigger;
        public State stateAkhir;
        public changeMode(State stateAwal, Trigger trigger, State stateAkhir)
        {
            this.stateAwal = stateAwal;
            this.trigger = trigger;
            this.stateAkhir = stateAkhir;
        }
    }

    private changeMode[] changes = {
        new changeMode( State.Quiet, Trigger.ModeUp, State.Balanced ),
        new changeMode( State.Balanced, Trigger.ModeUp, State.Performance),
        new changeMode( State.Performance, Trigger.ModeUp, State.Turbo),
        new changeMode( State.Turbo, Trigger.ModeDown, State.Performance),
        new changeMode( State.Performance, Trigger.ModeDown, State.Balanced),
        new changeMode( State.Balanced, Trigger.ModeDown, State.Quiet),
        new changeMode( State.Quiet, Trigger.TurboShortcut, State.Turbo),
        new changeMode( State.Balanced, Trigger.TurboShortcut, State.Turbo),
        new changeMode( State.Performance, Trigger.TurboShortcut, State.Turbo),
        new changeMode( State.Turbo, Trigger.TurboShortcut, State.Turbo)
    };

    public State GetNextState (State stateAwal, Trigger trigger)
    {
        for (int i = 0; i < changes.Length; i++)
        {
            if (changes[i].stateAwal == stateAwal && changes[i].trigger == trigger)
            {
                return changes[i].stateAkhir;
            }
        }
        return stateAwal;
    }
    
}   

class Program
{
    static void Main(string[] args)
    {
        KodeProduk kodeProduk = new KodeProduk();
        string kodeProdukVar = Console.ReadLine();
        Console.WriteLine(kodeProduk.getKodeProduk(kodeProdukVar));

        //TEST
        FanLaptop fanLaptop = new FanLaptop();
        Console.WriteLine("Masukkan state awal: ");
        string stateAwal = Console.ReadLine();
        Console.WriteLine("Masukkan trigger: ");
        string trigger = Console.ReadLine();
        FanLaptop.State state = (FanLaptop.State)Enum.Parse(typeof(FanLaptop.State), stateAwal);
        FanLaptop.Trigger triggerEnum = (FanLaptop.Trigger)Enum.Parse(typeof(FanLaptop.Trigger), trigger);
        Console.WriteLine(fanLaptop.GetNextState(state, triggerEnum));
    }
}