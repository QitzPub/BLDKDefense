using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : MonoBehaviour
{
    [SerializeField] EnemyType type;
    [SerializeField] float delay;
    [SerializeField] int health = 1;

    static readonly int FPS = 60;

    public Enemy Spawn(int frame)
    {
        if (delay * FPS < frame)
        {
            return ObjectManager.Instance.EnemyManager.SpawnEnemy(CreateEnemyParam(), transform.position, transform.rotation);
        }
        return null;
    }

    EnemyParam CreateEnemyParam()
    {
        return new EnemyParam(health, type);
    }

}
