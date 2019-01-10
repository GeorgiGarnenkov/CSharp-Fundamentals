using System;
using System.Collections.Generic;
using System.Linq;


public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.writer = writer;
        this.missionFactory = new MissionFactory();
        this.soldierFactory = new SoldierFactory();
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
    }
    

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {

            if (data[1] == "Regenerate")
            {
                this.army.RegenerateTeam(data[2]);
            }
            else
            {
                ISoldier soldier = soldierFactory.CreateSoldier(data[1], data[2], int.Parse(data[3]), double.Parse(data[4]), double.Parse(data[5]));

                if (this.wareHouse.TryEquipSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, data[1], data[2]));
                }
                
            }

        }
        else if (data[0].Equals("WareHouse"))
        {
            string ammunition = data[1];
            int quantity = int.Parse(data[2]);

            this.wareHouse.AddAmmunition(ammunition, quantity);
        }
        else if (data[0].Equals("Mission"))
        {
            var mission = this.missionFactory.CreateMission(data[1], double.Parse(data[2]));
            this.writer.StoreMessage(this.missionController.PerformMission(mission));
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        this.writer.StoreMessage("Results:");
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));
        this.writer.StoreMessage("Soldiers:");
        foreach (ISoldier soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            this.writer.StoreMessage(soldier.ToString());
        }
    }
}