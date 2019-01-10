using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Bag
{
    private List<GoldBag> goldBag;
    private List<GemBag> gemBag;
    private List<CashBag> cashBag;

    public Bag()
    {
        GoldBag = new List<GoldBag>();
        GemBag = new List<GemBag>();
        CashBag = new List<CashBag>();
    }
    
    public List<GoldBag> GoldBag
    {
        get => goldBag;
        set => goldBag = value;
    }

    public List<GemBag> GemBag
    {
        get => gemBag;
        set => gemBag = value;
    }

    public List<CashBag> CashBag
    {
        get => cashBag;
        set => cashBag = value;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if (GoldBag.Count > 0)
        {
            sb.AppendLine($"<Gold> ${GoldBag.Sum(a => a.Quantity)}");
            foreach (var kvp in GoldBag.OrderByDescending(k => k.Type).ThenBy(v => v.Quantity))
            {
                sb.AppendLine($"##{kvp.Type} - {kvp.Quantity}");
            }
        }
        if (GemBag.Count > 0)
        {
            sb.AppendLine($"<Gem> ${GemBag.Sum(a => a.Quantity)}");
            foreach (var kvp in GemBag.OrderByDescending(k => k.Type).ThenBy(v => v.Quantity))
            {
                sb.AppendLine($"##{kvp.Type} - {kvp.Quantity}");
            }
        }
        if (CashBag.Count > 0)
        {
            sb.AppendLine($"<Cash> ${CashBag.Sum(a => a.Quantity)}");
            foreach (var kvp in CashBag.OrderByDescending(k => k.Type).ThenBy(v => v.Quantity))
            {
                sb.AppendLine($"##{kvp.Type} - {kvp.Quantity}");
            }
        }

        return sb.ToString();
    }
}