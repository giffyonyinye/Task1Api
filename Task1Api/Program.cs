// See https://aka.ms/new-console-template for more information
using System;


namespace Task1Api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dogBreeds = new FetchDogBreed();
            while (true)
            {
                await dogBreeds.FetchAllDogBreeds();
                //Thread.Sleep(7200000);
                Thread.Sleep(1000);

            }
        }
    }
}

