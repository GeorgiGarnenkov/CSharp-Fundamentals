
namespace MilitaryElite
{
    public class Repair: IRepair
    {
        public Repair(string partName, int hoursForWork)
        {
            this.PartName = partName;
            this.HoursForWork = hoursForWork;
        }

        public string PartName { get; private set; }
        public int HoursForWork { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursForWork}";
        }
    }
}
