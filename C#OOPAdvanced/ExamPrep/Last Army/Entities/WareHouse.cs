using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionsQuantities;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.ammunitionsQuantities = new Dictionary<string, int>();
    }

    public void AddAmmunition(string ammunition, int quantity)
    {
        if (this.ammunitionsQuantities.ContainsKey(ammunition))
        {
            this.ammunitionsQuantities[ammunition] += quantity;
            }
        else
        {
            this.ammunitionsQuantities.Add(ammunition, quantity);
        }

    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        var isSoldierEquiped = true;

        foreach (var weapon in wornOutWeapons)
        {
            if (this.ammunitionsQuantities.ContainsKey(weapon) && this.ammunitionsQuantities[weapon] > 0)
            {
                soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
                this.ammunitionsQuantities[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }

        return isSoldierEquiped;
    }
}