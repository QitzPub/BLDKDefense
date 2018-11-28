using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParam 
{
    [SerializeField]
    int health = 1;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    EnemyType type = EnemyType.Normal;
    public EnemyType EnemyType
    {
        get
        {
            return type;
        }
    }
    public int Health
    {
        get
        {
            return health;
        }
    }

    public EnemyParam(int health, EnemyType type) {
        this.health = health;
        this.type = type;
    }
}
