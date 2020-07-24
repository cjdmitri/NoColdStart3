using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NoColdStart
{
    public class Tasks
    {

        public static async void TestTask()
        {
            try
            {
                HttpClient client = new HttpClient();
                while (true)
                {
                    Console.WriteLine($"Начало запроса https://localhost:5001/: { DateTime.Now.ToLongTimeString()}");
                    HttpResponseMessage response = await client.GetAsync("https://localhost:5001/");
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e)
            {
                //При возникновении ошибки останавливаем поток на минуту
                //после чего возобновляем
                Console.WriteLine(e);
                Thread.Sleep(60000);
                await Task.Run(() => TestTask());
            }
        }
    }
}
