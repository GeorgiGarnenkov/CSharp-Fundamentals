using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddReapir(IRepair repair);
    }
}