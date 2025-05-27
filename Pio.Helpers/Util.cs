using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ovning2.Abstractions;

namespace Pio.Helpers;

public static class Util
{



    public static bool IsChild(uint age) => age < 20;
    public static bool IsSinior(uint age) => age > 64;


    public static uint StrToUint(string num)
    {

        if (uint.TryParse(num, out uint _num))
        {
            return _num;
        }
        return 0;
    }


    public static bool ValidateAge(string age) => int.TryParse(age, out int x) && x >= 1;


    public static string AskForString(string prompt, IUI ui)
    {
        bool success = false;
        string answer;

        do
        {
            ui.Print($"{prompt}: ");
            answer = ui.GetInput();

            if (string.IsNullOrWhiteSpace(answer))
            {
                ui.Print($"You must enter a valid {prompt}");
            }
            else
            {
                success = true;
            }


        } while (!success);

        return answer;
    }


    public static uint AskForUint(string prompt, IUI ui)
    {
        do
        {
            string input = AskForString(prompt, ui);

            if (uint.TryParse(input, out uint result))
            {
                return result;
            }
            else
            {
                ui.Print($"{input} is not a valid uint");
            }

        } while (true);
    }




}
