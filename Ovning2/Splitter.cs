using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ovning2.Abstractions;

namespace Ovning2;



internal interface ISplitter
{
    bool SplitText(string txt, char letter, out string[] result);
}




internal class Splitter: ISplitter
{
    private const int _minWordNumber = 3;
    public bool SplitText(string txt, char letter, out string[] result) {
        string[] inputtxt = txt.Split(letter);

        //Handle the multiple char letter incounter.
        //Example:
        //input: SplitText("test   test", ' ')
        //output: ["test", "test"]
        //all the empty elemnts are removed
        //without this line the output would be: ["test", "", "", "", "test"]
        result = [.. inputtxt.Where(word => word != "")];
        if (result.Length >= _minWordNumber)
            return true;
        return false;
    }
}
