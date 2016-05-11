using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMq.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "192.168.1.100";
            factory.UserName = "yy";
            factory.Password = "hello!";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    bool durable = true;
                    channel.QueueDeclare("task_queue", durable, false, false, null);

                    string message = GetMessage(args);
                    var properties = channel.CreateBasicProperties();
                    properties.SetPersistent(true);


                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "task_queue", properties, body);
                    Console.WriteLine(" set {0}", message);
                }
            }

            Console.ReadKey();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
