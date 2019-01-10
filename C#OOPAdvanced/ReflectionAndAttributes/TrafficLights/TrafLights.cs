using System;
using System.Collections.Generic;
using System.Text;

public class TrafLights
{
    private Signal currentSignal;

    public TrafLights(string signal)
    {
        this.currentSignal = (Signal)Enum.Parse(typeof(Signal), signal);
    }

    public void Update()
    {
        int previous = (int)currentSignal;

        currentSignal = (Signal)(++previous % Enum.GetNames(typeof(Signal)).Length);
    }
}