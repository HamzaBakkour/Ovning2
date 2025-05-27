using Ovning2.Abstractions;
using Ovning2.UI;

namespace Ovning2;



internal class Program
{

    private static IPio _pio = new Pio();
    private static IUI _ui = new ConsoleUI();


    static void Main(string[] args)
    {
        IPio pio = new Pio();
        IUI ui = new ConsoleUI();

        Main main = new Main(ui, pio);
        main.Run();
    }
}
