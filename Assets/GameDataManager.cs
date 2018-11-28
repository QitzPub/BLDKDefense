using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

[Serializable]
class UserData
{
    public List<int> ranks = new List<int>();
    public void InitializeUserData()
    {
        ranks = new List<int>();
        for (int i = 0; i <= GameDataManager.Instance.maxLevel; i++)
        {
            ranks.Add((int)LevelRank.NotYet);
        }
    }
}

public enum LevelRank
{
    NotYet,
    D,
    C,
    B,
    A,
    S
}

public class GameDataManager : SingletonMonoBehaviour<GameDataManager>
{
    static readonly string USER_DATA_KEY = "USER_DATA_KEY";

    public int maxLevel;
    public int reachLevel;
    public int currentLevel;
    public int selectedLevel;

    public int Money { get; private set; }
    public float UnitPower { get; set; }

    UserData userData = new UserData();
    public int health = 5;

    [SerializeField] Canvas canvas;
    [SerializeField] ScorePresenter scorePresenter;
    public PowerPresenter leftPowerPresenter;
    public PowerPresenter rightPowerPresenter;

    new void Awake()
    {
        base.Awake();
    }

    public void InitializeForGameScene()
    {
        SetCanvasActive(true);
        Money = 0;
        leftPowerPresenter.Initialize();
        rightPowerPresenter.Initialize();
        scorePresenter.Initilize();
        UnitPower = 0;
        health = 5;
    }

    public void SetCanvasActive(bool isActive)
    {
        canvas.gameObject.SetActive(isActive);
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoadUserData()
    {
        userData = PlayerPrefsUtils.GetObject<UserData>(USER_DATA_KEY);
        if (userData == null)
        {
            userData = new UserData();
            userData.InitializeUserData();
        }
        else if (userData.ranks.Count == 0)
        {
            userData = new UserData();
            userData.InitializeUserData();
        }
    }

    public void SaveCurrentRank(LevelRank rank)
    {
        userData.ranks[currentLevel] = (int)rank;

        PlayerPrefsUtils.SetObject(USER_DATA_KEY, userData);
        PlayerPrefs.Save();
    }

    public LevelRank GetRank(int level)
    {
        return (LevelRank)Enum.ToObject(typeof(LevelRank), userData.ranks[level]);
    }

    public void AddMoney(int value)
    {
        Money += value;
        FindObjectOfType<MoneyManager>().UpdateText();
    }

    public void AddScore(int addition)
    {
        scorePresenter.AddScore(addition);
    }

    public void PowerUpRoundAttack()
    {
        if (GetCostRoundAttack() <= Money)
        {
            AddMoney(-GetCostRoundAttack());
            leftPowerPresenter.AddPower();
        }
    }

    int GetCostRoundAttack()
    {
        return (10 * (leftPowerPresenter.GetPower() + 1));
    }

    public float GetRoundAttackRate()
    {
        return (leftPowerPresenter.GetPower() + 1);
    }

    public void PowerUpStraightAttack()
    {
        if (GetCostStraightAttack() <= Money)
        {
            AddMoney(-GetCostStraightAttack());
            rightPowerPresenter.AddPower();
        }
    }

    int GetCostStraightAttack()
    {
        return (10 * (rightPowerPresenter.GetPower() + 1));
    }

    public float GetStraightAttackRate()
    {
        return (rightPowerPresenter.GetPower() + 1);
    }

}
