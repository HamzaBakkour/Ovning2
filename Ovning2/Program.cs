using Ovning2.Abstractions;
using Ovning2.UI;

namespace Ovning2;



internal class Program
{

    private static IPio _pio = new Pio();
    private static IUI _ui = new ConsoleUI();
    private static IRepeater _repeater = new Repeater();
    private static ISplitter _splitter = new Splitter();




    static void Main(string[] args)
    {
        IPio pio = new Pio();
        IUI ui = new ConsoleUI();
        IRepeater repeater = new Repeater();
        ISplitter splitter = new Splitter();

        Main main = new Main(ui, pio, repeater, splitter);
        main.Run();
    }
}
