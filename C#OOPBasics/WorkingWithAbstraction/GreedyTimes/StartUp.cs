using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        Bag bag = new Bag();

        long bagCapacity = long.Parse(Console.ReadLine());

        string[] itemsInput = Console.ReadLine()
            .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

        FillBag(bag, bagCapacity, itemsInput);

        Console.WriteLine(bag);
    }

    private static void FillBag(Bag bag, long bagCapacity, string[] itemsInput)
    {


        for (int i = 0; i < itemsInput.Length; i += 2)
        {
            long bagCurrentCap = 0;
            var item = itemsInput[i];
            long amount = long.Parse(itemsInput[i + 1]);


            if (item.ToLower() == "Gold".ToLower() &&
                CheckBagCapacity(bagCapacity, bagCurrentCap, amount))
            {
                GoldBag gold = new GoldBag();

                AddGold(bag, item, amount, gold);

                bagCurrentCap += amount;
            }

            if (item.Length > 3 &&
                item.ToLower().EndsWith("Gem".ToLower()) &&
                CheckBagCapacity(bagCapacity, bagCurrentCap, amount))
            {
                GemBag gem = new GemBag();

                long goldSum = bag.GoldBag.Sum(a => a.Quantity);
                long gemSum = bag.GemBag.Sum(a => a.Quantity);

                if (CheckAmountGoldGem(goldSum, gemSum, amount))
                {
                    AddGem(bag, item, amount, gem);

                    bagCurrentCap += amount;
                }
            }

            if (item.Length == 3 &&
                CheckBagCapacity(bagCapacity, bagCurrentCap, amount))
            {
                CashBag cash = new CashBag();

                var goldSum = bag.GoldBag.Sum(a => a.Quantity);
                var gemSum = bag.GemBag.Sum(a => a.Quantity);
                var cashSum = bag.CashBag.Sum(a => a.Quantity);

                if (CheckAmountGemCash(gemSum, cashSum, amount) &&
                    CheckAmountGoldCash(goldSum, cashSum, amount))
                {
                    AddCash(bag, item, amount, cash);

                    bagCurrentCap += amount;
                }
            }
        }
    }

    private void AddCash(Bag bag, string item, long amount, CashBag cash)
    {
        if (bag.CashBag.All(a => a.Type != item))
        {
            cash.Type = item;
            cash.Quantity = amount;
            bag.CashBag.Add(cash);
        }
        else
        {
            bag.CashBag.Find(a => a.Type == item).Quantity += amount;
        }
    }

    private void AddGem(Bag bag, string item, long amount, GemBag gem)
    {
        if (bag.GemBag.All(a => a.Type != item))
        {
            gem.Type = item;
            gem.Quantity = amount;
            bag.GemBag.Add(gem);
        }
        else
        {
            bag.GemBag.Find(a => a.Type == item).Quantity += amount;
        }
    }

    private void AddGold(Bag bag, string item, long amount, GoldBag gold)
    {
        if (bag.GoldBag.All(a => a.Type != item))
        {
            gold.Type = item;
            gold.Quantity = amount;
            bag.GoldBag.Add(gold);
        }
        else
        {
            bag.GoldBag.Find(a => a.Type == item).Quantity += amount;
        }
    }

    private bool CheckAmountGoldGem(long goldQuantity, long gemQuantity, long amount)
    {
        return goldQuantity >= gemQuantity + amount;
    }

    private bool CheckAmountGemCash(long gemQuantity, long cashQuantity, long amount)
    {
        return gemQuantity >= cashQuantity + amount;
    }

    private bool CheckAmountGoldCash(long goldQuantity, long cashQuantity, long amount)
    {
        return goldQuantity >= cashQuantity + amount;
    }

    private bool CheckBagCapacity(long bagCapacity, long bagCurrentCap, long amount)
    {
        return bagCapacity >= bagCurrentCap + amount;
    }
}