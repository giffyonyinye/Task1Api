using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1Api
{
    public class FetchDogBreed
    {
        public async Task FetchAllDogBreeds()
        {
            string folderPath = "C:\\Users\\onyinyechi.odiegwu\\source\\repos\\Task1Api\\Task1Api";
            string fileName = "dog_breeds.txt";
            string fullPath = folderPath + fileName;
            string url = "https://dog.ceo/api/breeds/list/all";
           try
            {
                using (HttpClient client =new HttpClient())
                {
                   /* client.DefaultRequestHeaders.Add("x-rapidapi-key", "dbb99f5902msh4b77a1f0fe49d35p1421b2jsn3983bffc1940");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "movie-database-alternative.p.rapidapi.com");*/

                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string data = content.ReadAsStringAsync().Result;
                            if (data != null)
                            {
                                var dataObj = JObject.Parse(data);
                                using (StreamWriter writer = new StreamWriter(fullPath))
                                {
                                    writer.WriteLine($"Log Time: {DateTime.Now}");
                                    foreach (var breed in dataObj)
                                    {
                                        writer.WriteLine(breed.ToString());
                                    }
                                    writer.WriteLine(new string('-', 20));
                                }
                                Console.WriteLine(dataObj);
                            }
                            else
                            {
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
