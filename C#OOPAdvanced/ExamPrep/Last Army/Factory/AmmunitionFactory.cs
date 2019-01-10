using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammunitionType = this.GetAmmunitionType(ammunitionName);

        return (IAmmunition)Activator.CreateInstance(ammunitionType, ammunitionName);
    }

    private Type GetAmmunitionType(string ammunitionName)
    {
        Type[] assemblyTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        return assemblyTypes.FirstOrDefault(t => t.Name == ammunitionName);
    }
}