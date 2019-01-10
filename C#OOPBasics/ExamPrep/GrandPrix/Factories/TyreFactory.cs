﻿using System;

public class TyreFactory
{
    public Tyre CreateTyre(string[] tyreArgs)
    {
        string tyreType = tyreArgs[0];
        double tyreHardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        if (tyreType == "Hard")
        {
            tyre = new HardTyre(tyreHardness);

            return tyre;
        }
        else if (tyreType == "Ultrasoft")
        {
            double tyreGrip = double.Parse(tyreArgs[2]);
            tyre = new UltrasoftTyre(tyreHardness, tyreGrip);

            return tyre;
        }

        throw new ArgumentException(OutputMessages.InvalidTyreType);
    }
}