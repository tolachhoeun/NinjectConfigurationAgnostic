using System;

namespace NinjectConfigurationAgnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrap = new Bootstrap();
            bootstrap.Run();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
