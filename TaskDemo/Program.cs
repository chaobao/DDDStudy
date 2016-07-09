using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        private static object o = new object();
        /*定义 Queue*/
        private static Queue<Product> _Products { get; set; }
        private static ConcurrentQueue<Product> _ConcurrenProducts { get; set; }

        static void Main(string[] args)
        {
            _Products = new Queue<Product>();
            Stopwatch swTask = new Stopwatch();
            /*创建任务 t1  t1 执行 数据集合添加操作*/
            Task t1 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });
            /*创建任务 t2  t2 执行 数据集合添加操作*/
            Task t2 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });
            /*创建任务 t3  t3 执行 数据集合添加操作*/
            Task t3 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });

            swTask.Stop();
            Console.WriteLine("List<Product> 当前数据量为：" + _Products.Count);
            Console.WriteLine("List<Product> 执行时间为：" + swTask.ElapsedMilliseconds);
            _ConcurrenProducts = new ConcurrentQueue<Product>();
            Stopwatch swTask1 = new Stopwatch();
            swTask1.Start();

            /*创建任务 tk1  tk1 执行 数据集合添加操作*/
            Task tk1 = Task.Factory.StartNew(() =>
            {
                AddConcurrenProducts();
            });
            /*创建任务 tk2  tk2 执行 数据集合添加操作*/
            Task tk2 = Task.Factory.StartNew(() =>
            {
                AddConcurrenProducts();
            });
            /*创建任务 tk3  tk3 执行 数据集合添加操作*/
            Task tk3 = Task.Factory.StartNew(() =>
            {
                AddConcurrenProducts();
            });

            Task.WaitAll(tk1, tk2, tk3);
            swTask1.Stop();
            Console.WriteLine("ConcurrentQueue<Product> 当前数据量为：" + _ConcurrenProducts.Count);
            Console.WriteLine("ConcurrentQueue<Product> 执行时间为：" + swTask1.ElapsedMilliseconds);
            Console.ReadLine();
        }

        /*执行集合数据添加操作*/
        static void AddProducts()
        {
            Parallel.For(0, 30000, (i) =>
            {
                Product product = new Product();
                product.Name = "name" + i;
                product.Category = "Category" + i;
                product.SellPrice = i;
         
                    _Products.Enqueue(product);
                
            });

        }
        /*执行集合数据添加操作*/
        static void AddConcurrenProducts()
        {
            Parallel.For(0, 30000, (i) =>
            {
                Product product = new Product();
                product.Name = "name" + i;
                product.Category = "Category" + i;
                product.SellPrice = i;
                _ConcurrenProducts.Enqueue(product);
            });

        }
    }

    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int SellPrice { get; set; }
    }
}
