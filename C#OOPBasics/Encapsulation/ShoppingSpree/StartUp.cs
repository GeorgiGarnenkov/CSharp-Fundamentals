using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        try
        {
            var inputPersons = Console.ReadLine()
                .Split(new []{';', '='});
            List<Person> people = new List<Person>();
            for (int i = 0; i < inputPersons.Length; i += 2)
            {
                var name = inputPersons[i];
                var money = decimal.Parse(inputPersons[i + 1]);
                Person person = new Person(name, money);
                people.Add(person);

            }

            var inputProducts = Console.ReadLine()
                .Split(new[] { ';', '=' },StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            for (int i = 0; i < inputProducts.Length; i += 2)
            {
                var productName = inputProducts[i];
                var productCost = decimal.Parse(inputProducts[i + 1]);

                Product product = new Product(productName, productCost);
                products.Add(product);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var commandArgs = input.Split(' ');

                var personName = commandArgs[0];
                var productName = commandArgs[1];

                Person person = people.FirstOrDefault(a => a.Name == personName);
                Product product = products.FirstOrDefault(a => a.Name == productName);

                person.BuyProduct(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString().Trim());
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
}