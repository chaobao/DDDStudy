using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using ClrWeb.Lib.Events;
using EnumDemo.Lib.Events;

namespace EnumDemo
{
    internal delegate void Feedback(Int32 value);

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

            //TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();
            //twle.Foo += HandlerFooEvent;
            //twle.SimulateFoo();
            //Console.ReadKey();
            Console.WriteLine("Main thread:Queruing an asynchronous operation...");
            ThreadPool.QueueUserWorkItem(ComputerBoundOp, 5);
            Console.WriteLine("Main thread:Doing other work here...");
            Thread.Sleep(10000);
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        private static void ComputerBoundOp(object state)
        {
            Console.WriteLine("In ComputeBoundOp:State={0}", state);
            Thread.Sleep(1000);
        }

        private static void HandlerFooEvent(object sender, FooEventArgs e)
        {
            Console.WriteLine("Handling Foo Event here...");
        }

        private static void StaticDelegateDemo()
        {
            Console.WriteLine("---Static Delegate Demo---");
            Feedback fb1 = new Feedback(FeedbackToMsgBox);
        }

        private static void Counter(Int32 from,int to,Feedback fb)
        {
            for (int val = from; val <= to; val++)
            {
                if (fb!=null)
                {
                    fb(val);
                }
            }
        }

        private static void FeedbackToMsgBox(Int32 value)
        {
          //  MessageBox
        }

        private void FeedbackToFile(Int32 value)
        {
            StreamWriter sw = new StreamWriter("status",true);
            sw.WriteLine("Item=" + value);
            sw.Close();
        }
        public class Type2
        {
            static Type2() {
                Console.WriteLine("Type2 is static  ctor called");
            }
        }
    }
}
