using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning2;

internal interface IRepeater
{
     string Repeat(string txt, int numRepeat);
}

internal class Repeater: IRepeater
{
    public string Repeat(string txt, int numRepeat) {

        string result = string.Empty;
        for (int i = 1; i <= numRepeat; i++)
        {
            result += i == numRepeat ? $"output{i}: {txt}" : $"output{i}: {txt}, ";
        }
        return result;
    }

}
