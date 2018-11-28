using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterData {
    public static int GetRoot(EnemyType type) {
        int money = 0;
        switch (type)
        {
            case EnemyType.Normal:
                money = 10;
                break;
            case EnemyType.Walker:
                money = 10;
                break;
            case EnemyType.Climber:
                money = 10;
                break;
            case EnemyType.Ghost:
                money = 10;
                break;
            case EnemyType.Jet:
                money = 10;
                break;
            case EnemyType.Jumper:
                money = 10;
                break;
            case EnemyType.Armor:
                money = 10;
                break;
            case EnemyType.ArmorJet:
                money = 10;
                break;
        }
        return money;
    }
}