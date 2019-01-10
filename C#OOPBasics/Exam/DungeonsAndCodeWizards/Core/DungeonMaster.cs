using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Characters.Interfaces;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Factories;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private readonly List<Character> party;
        private readonly Stack<Item> itemsPool;

        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemsPool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var characterFaction = args[0];
            var characterType = args[1];
            var characterName = args[2];

            var character = this.characterFactory.CreateCharacter(characterFaction, characterType, characterName);

            this.party.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            var item = this.itemFactory.CreateItem(itemName);

            this.itemsPool.Push(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = FindCharacter(characterName);

            var anyItemsLeft = itemsPool.Any();
            if (!anyItemsLeft)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.itemsPool.Pop();

            character.ReceiveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";

        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = FindCharacter(characterName);
            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giverCharacter = this.FindCharacter(giverName);
            var receiverCharacter = this.FindCharacter(receiverName);
            var item = giverCharacter.Bag.GetItem(itemName);

            giverCharacter.UseItemOn(item, receiverCharacter);

            return $"{giverCharacter.Name} used {itemName} on {receiverCharacter.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giverCharacter = this.FindCharacter(giverName);
            var receiverCharacter = this.FindCharacter(receiverName);
            var item = giverCharacter.Bag.GetItem(itemName);

            giverCharacter.GiveCharacterItem(item, receiverCharacter);

            return $"{giverCharacter.Name} gave {receiverCharacter.Name} {itemName}.";
        }

        public string GetStats()
        {
            var sortedCharacters = this.party
                .OrderByDescending(a => a.IsAlive)
                .ThenByDescending(a => a.Health);

            var result = string.Join(Environment.NewLine, sortedCharacters);
            return result;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = this.FindCharacter(attackerName);
            var receiver = this.FindCharacter(receiverName);

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attackingCharacter.Attack(receiver);

            var result =
                $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var receiverName = args[1];

            var healer = this.FindCharacter(healerName);
            var receiver = this.FindCharacter(receiverName);

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            healingCharacter.Heal(receiver);

            var result =
                $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = party.Where(c => c.IsAlive).ToArray();

            var sb = new StringBuilder();

            foreach (var character in aliveCharacters)
            {
                var healthBeforeRest = character.Health;

                character.Rest();

                var currentHealth = character.Health;

                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {currentHealth})");
            }

            if (aliveCharacters.Length <= 1)
            {
                this.lastSurvivorRounds++;
            }

            var result = sb.ToString().TrimEnd('\r', '\n');
            return result;
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.party.Count(c => c.IsAlive) <= 1;
            var lastSurviverSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }

        private Character FindCharacter(string name)
        {
            var character = this.party.FirstOrDefault(a => a.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }
    }
}
