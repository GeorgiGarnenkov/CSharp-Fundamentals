using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedyTimes
{
    class GreedyTimes
    {
        static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] itemsInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var goldBag = new Dictionary<string, long>();
            long goldQuantity = 0;

            var gemBag = new Dictionary<string, long>();
            long gemQuantity = 0;

            var cashBag = new Dictionary<string, long>();
            long cashQuantity = 0;

            long bagCurrentCap = 0;

            for (int i = 0; i < itemsInput.Length; i += 2)
            {
                var item = itemsInput[i];
                long amount = long.Parse(itemsInput[i + 1]);

                if (item.ToLower() == "Gold".ToLower() && CheckBagCapacity(bagCapacity, bagCurrentCap, amount))
                {
                    if (!goldBag.ContainsKey(item))
                    {
                        goldBag.Add(item, amount);
                        goldQuantity += amount;
                        bagCurrentCap += amount;
                    }
                    else
                    {
                        goldBag[item] += amount;
                        goldQuantity += amount;
                        bagCurrentCap += amount;
                    }
                }

                if (item.Length > 3 && item.ToLower().EndsWith("Gem".ToLower()) && CheckBagCapacity(bagCapacity, bagCurrentCap, amount))
                {
                    var gemAmount = amount;
                    if (CheckAmountGoldGem(goldQuantity, gemQuantity, gemAmount))
                    {
                        if (!gemBag.ContainsKey(item))
                        {
                            gemBag.Add(item, gemAmount);
                            gemQuantity += gemAmount;
                            bagCurrentCap += gemAmount;
                        }
                        else
                        {
                            gemBag[item] += gemAmount;
                            gemQuantity += gemAmount;
                            bagCurrentCap += gemAmount;
                        }
                    }
                }

                if (item.Length == 3 && CheckBagCapacity(bagCapacity, bagCurrentCap, amount))
                {
                    var cashAmount = amount;
                    if (CheckAmountGemCash(gemQuantity, cashQuantity, cashAmount) && 
                        CheckAmountGoldCash(goldQuantity, cashQuantity, cashAmount))
                    {
                        if (!cashBag.ContainsKey(item))
                        {
                            cashBag.Add(item, cashAmount);
                            cashQuantity += cashAmount;
                            bagCurrentCap += cashAmount;
                        }
                        else
                        {
                            cashBag[item] += cashAmount;
                            cashQuantity += cashAmount;
                            bagCurrentCap += cashAmount;
                        }
                    }
                }
            }

            if (goldBag.Count > 0)
            {
                Console.WriteLine($"<Gold> ${goldQuantity}");
                foreach (var kvp in goldBag.OrderByDescending(k => k.Key).ThenBy(v => v.Value))
                {
                    Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
                }
            }
            if (gemBag.Count > 0)
            {
                Console.WriteLine($"<Gem> ${gemQuantity}");
                foreach (var kvp in gemBag.OrderByDescending(k => k.Key).ThenBy(v => v.Value))
                {
                    Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
                }
            }
            if (cashBag.Count > 0)
            {
                Console.WriteLine($"<Cash> ${cashQuantity}");
                foreach (var kvp in cashBag.OrderByDescending(k => k.Key).ThenBy(v => v.Value))
                {
                    Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
                }
            }

        }

        static bool CheckAmountGoldGem(long goldQuantity, long gemQuantity, long gemAmount)
        {
            return goldQuantity >= gemQuantity + gemAmount;
        }
        static bool CheckAmountGemCash(long gemQuantity, long cashQuantity, long cashAmount)
        {
            return gemQuantity >= cashQuantity + cashAmount;
        }
        static bool CheckAmountGoldCash(long goldQuantity, long cashQuantity, long cashAmount)
        {
            return goldQuantity >= cashQuantity + cashAmount;
        }

        static bool CheckBagCapacity(long bagCapacity, long bagCurrentCap, long amount)
        {
            return bagCapacity >= bagCurrentCap + amount;
        }
    }
}
