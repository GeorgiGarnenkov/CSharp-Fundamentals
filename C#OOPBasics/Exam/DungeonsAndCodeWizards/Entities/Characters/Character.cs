using System;
using System.Linq;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private string name;

        private double baseHealth;
        private double health;

        private double baseArmor;
        private double armor;

        private double abilityPoints;


        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

            this.Faction = faction;
        }

        // Prop...

        public bool IsAlive { get; set; } = true;

        public Bag Bag { get; }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth
        {
            get => this.baseHealth;
            private set => this.baseHealth = value;
        }

        public double Health
        {
            get => this.health;
            set => this.health = Math.Min(value, this.BaseHealth);
        }

        public double BaseArmor
        {
            get => this.baseArmor;
            private set => this.baseArmor = value;
        }

        public double Armor
        {
            get => this.armor;
            set => this.armor = Math.Min(value, this.BaseArmor);
        }

        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set => this.abilityPoints = value;
        }

        public Faction Faction { get; }

        protected virtual double RestHealMultiplier => 0.2;

        // Methods...

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }

        }

        public void Rest()
        {
            EnsureAlive();

            this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);

        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            character.EnsureAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            character.EnsureAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            EnsureAlive();

            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            var isAliveString = String.Empty;
            if (IsAlive)
            {
                isAliveString = "Alive";
            }
            else
            {
                isAliveString = "Dead";
            }
            return $"{this.Name} - HP: {this.Health}/{this.baseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {isAliveString}";
        }
    }
}
