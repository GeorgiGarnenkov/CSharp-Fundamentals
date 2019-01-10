using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IFeed
    {
        void FeedTheAnimal(string foodType, int quantity);
    }
}
