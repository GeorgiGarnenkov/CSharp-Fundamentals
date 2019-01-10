using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            int lastIndex = this.stones.Count - 1;
            if (lastIndex % 2 == 0)
            {
                lastIndex--;
            }

            for (int i = lastIndex; i > 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
