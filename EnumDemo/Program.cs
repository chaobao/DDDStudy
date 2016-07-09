using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RuntimeHelpers.PrepareConstrainedRegions();
            //Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            //Console.WriteLine("Number of symbols defined:" + colors.Length);
            //Console.WriteLine("Value\tSymbol\n----\t-----");
            //foreach (Color c in colors)
            //{
            //    Console.WriteLine("{0,5:D}\t{0:G}", c);
            //}
          

            //Color orange = (Color)Enum.Parse(typeof(Color), "orange", true);
            //Console.WriteLine(orange);

            //Console.WriteLine("位标志Attribute");
            //Actions actions = Actions.Read | Actions.Delete;

            //Console.WriteLine(actions.ToString());

            //var kids = new[] { new { Name="Aidan"}, new { Name="Grant"} };
            //foreach (var kid in kids)
            //{
            //    Console.WriteLine(kid.Name);
            //}
            //Console.ReadKey();

            
        }

        public class Type2
        {
            static Type2() {
                Console.WriteLine("Type2 is static  ctor called");
            }
        }
    }
}
