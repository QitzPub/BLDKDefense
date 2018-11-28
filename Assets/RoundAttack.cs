using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoundAttack : AbstractAttack
{
    int damage = 4;
    readonly float range = 1.5f;
    Vector3 position;
    public int comsumption = 3;

    public RoundAttack(Vector3 pos)
    {
        position = pos;
    }

    public override int GetComsumption()
    {
        return comsumption;
    }

    public override void Animate(Vector3 pos)
    {
        var rose = UnityEngine.Object.Instantiate(PrefabHolder.Instance.roundRose, pos, Quaternion.identity);
        rose.Animate();
    }

    public override Func<Vector3, bool> IsInRange
    {
        get
        {
            return (pos) => Vector2.Distance(new Vector2(pos.x, pos.z), new Vector2(position.x, position.z)) <= range;
        }
    }

    public override int GetDamage()
    {
        return damage * GameDataManager.Instance.leftPowerPresenter.GetPower();
    }
}
