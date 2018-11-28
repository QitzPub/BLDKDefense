using UnityEngine;
using System.Collections;
using UniRx;

public class PowerModel
{
    ReactiveProperty<int> power;
    public IReadOnlyReactiveProperty<int> Power
    {
        get
        {
            return power;
        }
    }

    public PowerModel()
    {
        power = new ReactiveProperty<int>(1);
    }

    public void SetPower(int power)
    {
        this.power.Value = power;
    }
}
