using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInputBehaviour : InputBehaviour
{
    public override void Execute()
    {
        GameDataManager.Instance.PowerUpRoundAttack();
    }
}
