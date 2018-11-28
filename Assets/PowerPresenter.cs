using UnityEngine;
using System.Collections;
using UniRx;

public class PowerPresenter : MonoBehaviour
{
    PowerModel model;
    [SerializeField] PowerView view;

    public void Initialize()
    {
        model = new PowerModel();
        model.Power
            .Subscribe(i => view.OnPowerChanged(i));
        model.SetPower(1);
    }

    public void AddPower()
    {
        model.SetPower(model.Power.Value + 1);
    }

    public int GetPower()
    {
        return model.Power.Value;
    }
}
