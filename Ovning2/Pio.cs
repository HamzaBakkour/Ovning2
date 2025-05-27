using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pio.Helpers;


namespace Ovning2
{

    internal interface IPio
    {
        string SinglePrice(string age);
        uint GroupPrice(List<uint> ages);
    }

    internal class Pio: IPio
    {

        public string SinglePrice(string age) {

            uint _age = uint.Parse(age);

            if (Util.IsChild(_age))
            {
                return $"Child Price: {PriceCategory.ChildPrice}kr";
            }
            else if (Util.IsSinior(_age))
            {
                return $"Sinior Price:  {PriceCategory.SiniorPrice}kr";

            }
            return $"Standard Price:  {PriceCategory.StandardPrice}kr";
        }



        public uint GroupPrice(List<uint> ages)
        {
            uint totalCost = 0;

            foreach (var age in ages) {
                if (Util.IsChild(age))
                {
                    totalCost += PriceCategory.ChildPrice;
                }
                else if (Util.IsSinior(age))
                {
                    totalCost += PriceCategory.SiniorPrice;
                }
                else
                {
                    totalCost += PriceCategory.StandardPrice;
                }
            }
            return totalCost;
        }
    }
 }





