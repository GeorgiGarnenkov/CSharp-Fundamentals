using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion()
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;

        }
    }
}
