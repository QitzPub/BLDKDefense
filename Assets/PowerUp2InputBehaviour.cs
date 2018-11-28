using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2InputBehaviour : InputBehaviour
{
    public override void Execute()
    {
        GameDataManager.Instance.PowerUpStraightAttack();
    }
}
