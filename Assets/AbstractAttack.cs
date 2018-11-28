using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAttack
{
    public abstract Func<Vector3, bool> IsInRange { get; }

    public abstract int GetDamage();

    public abstract int GetComsumption();

    public abstract void Animate(Vector3 pos);

}
