using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.ViewModels
{
    public abstract class ContentViewModel
    {
        private const int lineLength = 37;


        protected ContentViewModel(string text)
        {
            this.Content = this.GetLines(text);
        }
        
        public string[] Content { get; }

        private string[] GetLines(string text)
        {
            char[] constentChar = text.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < text.Length; i += lineLength)
            {
                char[] row = constentChar.Skip(i).Take(lineLength).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}