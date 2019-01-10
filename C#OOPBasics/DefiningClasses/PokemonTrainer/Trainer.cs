using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public string Name { get; set; }

    public int Badges { get; set; }

    public List<Pokemon> Collection { get; set; } = new List<Pokemon>();

    public void CheckForElement(Trainer trainer, string elementInput)
    {
        if (trainer.Collection.FirstOrDefault(a => a.Element == elementInput) == null)
        {
            for (var i = 0; i < trainer.Collection.Count; i++)
            {
                var pokemon = trainer.Collection[i];

                pokemon.Health -= 10;

                trainer.Collection.RemoveAll(a => a.Health <= 0);
            }
        }
        else
        {
            trainer.Badges++;
        }
    }
}