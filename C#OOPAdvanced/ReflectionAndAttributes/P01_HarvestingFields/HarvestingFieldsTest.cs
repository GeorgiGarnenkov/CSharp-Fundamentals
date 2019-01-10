using System.Reflection;
using System.Text;
using System;
using System.Linq;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        string input;

        while ((input = Console.ReadLine()) != "HARVEST")
        {
            var command = input;

            switch (command)
            {
                case "private":
                    Console.WriteLine(PrintAllPrivateFields());
                    break;
                case "protected":
                    Console.WriteLine(PrintAllProtectedFields());
                    break;
                case "public":
                    Console.WriteLine(PrintAllPublicFields());
                    break;
                case "all":
                    Console.WriteLine(PrintAllFields());
                    break;
            }
        }
    }

    private static string PrintAllFields()
    {
        StringBuilder sb = new StringBuilder();
        var fields = Type
            .GetType(typeof(HarvestingFields).Name)
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            var access = field.Attributes.ToString().ToLower();
            if (access == "family")
            {
                access = "protected";
            }

            sb.AppendLine($"{access} {field.FieldType.Name} {field.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    private static string PrintAllPublicFields()
    {
        StringBuilder sb = new StringBuilder();
        var fields = Type
            .GetType(typeof(HarvestingFields).Name)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            var access = field.Attributes.ToString().ToLower();

            sb.AppendLine($"{access} {field.FieldType.Name} {field.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    private static string PrintAllProtectedFields()
    {
        StringBuilder sb = new StringBuilder();
        var fields = Type
            .GetType(typeof(HarvestingFields).Name)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(p => p.IsFamily);

        foreach (FieldInfo field in fields)
        {
            var access = field.Attributes.ToString().ToLower();
            if (access == "family")
            {
                access = "protected";
            }

            sb.AppendLine($"{access} {field.FieldType.Name} {field.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    private static string PrintAllPrivateFields()
    {
        StringBuilder sb = new StringBuilder();
        var fields = Type
            .GetType(typeof(HarvestingFields).Name)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(p => p.IsPrivate);

        foreach (FieldInfo field in fields)
        {
            var access = field.Attributes.ToString().ToLower();

            sb.AppendLine($"{access} {field.FieldType.Name} {field.Name}");
        }

        return sb.ToString().TrimEnd();
    }
}