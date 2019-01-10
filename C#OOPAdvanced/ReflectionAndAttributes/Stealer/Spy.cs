using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        var fields = Type
            .GetType(classToInvestigate)
            .GetFields(BindingFlags.Instance |
                       BindingFlags.Static |
                       BindingFlags.Public |
                       BindingFlags.NonPublic);

        var classInstance = Activator
            .CreateInstance(Type.GetType(classToInvestigate));

        foreach (FieldInfo field in fields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
        }

        return sb.ToString().TrimEnd();
    }

}