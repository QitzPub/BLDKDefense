using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy normal;
    [SerializeField] Enemy walker;
    [SerializeField] Enemy climber;
    [SerializeField] Enemy ghost;
    [SerializeField] Enemy jet;
    [SerializeField] Enemy jumper;
    [SerializeField] Enemy armor;
    [SerializeField] Enemy armorJet;

    public Enemy SpawnEnemy(EnemyParam enemyParam, Vector3 position, Quaternion quaternion)
    {
        Enemy enemy;
        switch (enemyParam.EnemyType)
        {
            case EnemyType.Normal:
                enemy = normal;
                break;
            case EnemyType.Walker:
                enemy = walker;
                break;
            case EnemyType.Climber:
                enemy = climber;
                break;
            case EnemyType.Ghost:
                enemy = ghost;
                break;
            case EnemyType.Jet:
                enemy = jet;
                break;
            case EnemyType.Jumper:
                enemy = jumper;
                break;
            case EnemyType.Armor:
                enemy = armor;
                break;  
            case EnemyType.ArmorJet:
                enemy = armorJet;
                break;
            default:
                enemy = normal;
                break;
        }
        enemy = Instantiate(enemy, position, quaternion);
        enemy.Initialize(enemyParam);
        return enemy;
    }
}
