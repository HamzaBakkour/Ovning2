﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ovning2.Abstractions;

namespace Ovning2.UI;
public class ConsoleUI: IUI
{

    public void Print(string message) {
        Console.WriteLine(message);
    }

    public string GetInput() {
        return Console.ReadLine() ?? string.Empty;
    }

}
