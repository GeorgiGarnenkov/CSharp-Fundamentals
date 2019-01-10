﻿using System;
using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion()
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health = Math.Max(0, character.Health - 20);

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }

        }
    }
}
