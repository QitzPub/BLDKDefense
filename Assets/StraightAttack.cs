using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StraightAttack : AbstractAttack
{
    int damage = 3;
    float range = 7.5f;
    readonly float halfWidth = 1f;
    Vector3 clickPosition;
    public int comsumption = 3;
    MainCharacter unit;

    public StraightAttack(Vector3 pos)
    {
        clickPosition = pos;
        unit = UnityEngine.Object.FindObjectOfType<MainCharacter>();
    }

    public override Func<Vector3, bool> IsInRange
    {
        get
        {
            return (target) =>
            {
                float distance = Vector2.Distance(new Vector2(target.x, target.z), new Vector2(unit.transform.position.x, unit.transform.position.z));
                if (range < distance)
                {
                    return false;
                }

                Vector3 to = target - unit.transform.position;
                to.y = 0;
                Vector3 from = unit.transform.forward;
                float degree = Vector3.Angle(from, to);
                float distanceFromLine = to.magnitude * Mathf.Sin(degree * Mathf.Deg2Rad);
                bool isInRange = distanceFromLine <= halfWidth;
                return isInRange;
            };
        }
    }

    public override int GetDamage()
    {
        return damage * GameDataManager.Instance.rightPowerPresenter.GetPower();
    }

    public override int GetComsumption()
    {
        return comsumption;
    }

    public override void Animate(Vector3 pos)
    {
        var attack = UnityEngine.Object.Instantiate(PrefabHolder.Instance.straightRose, unit.transform.position, Quaternion.identity);
        attack.GetComponentsInChildren<RoseTween>()
              .ToList()
              .ForEach(r => r.Animate());
        attack.transform.eulerAngles = unit.transform.eulerAngles + Vector3.up * 90;
    }

}
