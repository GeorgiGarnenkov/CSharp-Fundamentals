using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando: ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
        
        void AddMission(IMission mission);
        void CompleteMission(string missionCodeName);
    }
}