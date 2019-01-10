using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        TrafLights[] trafficLights = new TrafLights[input.Length];

        for (int i = 0; i < trafficLights.Length; i++)
        {
            trafficLights[i] = (TrafLights)Activator.CreateInstance(typeof(TrafLights), new object[] { input[i] });
        }

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            List<string> result = new List<string>();
            foreach (var trafficLight in trafficLights)
            {
                trafficLight.Update();
                var field = typeof(TrafLights).GetField("currentSignal", BindingFlags.NonPublic | BindingFlags.Instance);
                result.Add(field.GetValue(trafficLight).ToString());
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}