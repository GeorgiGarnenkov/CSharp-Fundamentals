using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILeutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier soldier);
    }
}