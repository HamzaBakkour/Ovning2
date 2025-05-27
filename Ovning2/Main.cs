using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ovning2.Abstractions;
using Pio.Helpers;
using UI.Helpers;

namespace Ovning2;

internal class Main
{
    private IUI _ui;
    private IPio _pio;
    private IRepeater _repeater;
    private ISplitter _splitter;


    public Main(IUI ui, IPio pio, IRepeater repeater, ISplitter splitter) {
        this._ui = ui;
        this._pio = pio;
        this._repeater = repeater;
        this._splitter = splitter;
    }

    public void Run() {

        do
        {
            ShowMainMeny();
            string input = _ui.GetInput();
            switch (input.ToUpper())
            {
                case MenyHelpers.PioSingle:
                    SingleTicket();
                    break;
                case MenyHelpers.PioGroup:
                    GroupTickets();
                    break;
                case MenyHelpers.Repeater:
                    RepeatTenTimes();
                    break;
                case MenyHelpers.Splitter:
                    SplitText();
                    break;
                case MenyHelpers.Quit:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        } while (true);

    }


    private void ShowMainMeny() {
        _ui.Print($"{MenyHelpers.PioSingle}. Pio - Single ticket.");
        _ui.Print($"{MenyHelpers.PioGroup}. Pio - Group ticket.");
        _ui.Print($"{MenyHelpers.Repeater}. Repeat an inout 10 times.");
        _ui.Print($"{MenyHelpers.Splitter}. Splitter.");

        _ui.Print($"{MenyHelpers.Quit}. Exit");

    }

    private void SingleTicket() {

        string age = string.Empty;
        do{
            age  = Util.AskForString("Age: ", _ui);
        } while (!IsValidAge(age));

        _ui.Print(_pio.SinglePrice(age));
    }


    private bool IsValidAge(string age) {
        if (!Util.ValidateAge(age))
        {
            _ui.Print($"{age} is not a valid age");
            return false;
        }
        return true;
    }

    private void GroupTickets()
    {
        List<uint> ages = [];
        uint num = Util.AskForUint("Enter number of customers: ", _ui);
        for (int i = 1; i <= num; i++) {
            uint age = Util.AskForUint("Age: ", _ui);
            ages.Add(age);
        }
        _ui.Print($"Total cost: {_pio.GroupPrice(ages)}kr");
    }


    private void RepeatTenTimes() {
        string input = Util.AskForString("Enter an input to repeat it 10 times", _ui);
        _ui.Print(_repeater.Repeat(input, 10));
    }

    private void SplitText() {
        do
        {
            string input = Util.AskForString("Enter a string of at least" +
            " three words to get back the third word: ", _ui);
            if (_splitter.SplitText(input, ' ', out string[] result)){
                _ui.Print($"The third word is {result[2]}");
                break;
            }

        } while (true);
    }

}


