using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<string> bagOfProducts;

    public Person(string name , decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<string>();
    }
    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<string> BagOfProducts
    {
        get { return this.bagOfProducts; }
    }

    public void BuyProduct(Product product)
    {
        if (product.Cost > this.Money)
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.Name} bought {product.Name}");

            this.Money -= product.Cost;
            this.bagOfProducts.Add(product.Name);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        if (this.bagOfProducts.Count != 0)
        {
            sb.AppendLine($"{this.Name} - {string.Join(", ", this.bagOfProducts)}");
        }
        else
        {
            sb.AppendLine($"{this.Name} - Nothing bought");
        }

        return sb.ToString();
    }
}
