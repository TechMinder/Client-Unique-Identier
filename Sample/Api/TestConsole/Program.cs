using SampleApi.Client;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("https://localhost:44319", "Console");
            
            try
            {
                var result = client.Get().Result;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                var result = client.Post("call chaining").Result;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
