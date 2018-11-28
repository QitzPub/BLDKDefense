using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {
    Round,
    Straight,
}

public class AttackFactory
{
    public AbstractAttack CreateAttack(Vector3 pos, AttackType type)
    {
        AbstractAttack attack = null;
        switch (type)
        {
            case AttackType.Round:
                attack = new RoundAttack(pos);
                break;
            case AttackType.Straight:
                attack = new StraightAttack(pos);
                break;
        }
        return attack;
    }



}
