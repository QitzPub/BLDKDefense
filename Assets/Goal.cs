using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : CheckPoint
{
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 distance;
    [SerializeField] GameObject indicater;

    List<GameObject> indicaters = new List<GameObject>();

    public int GetHealth()
    {
        return GameDataManager.Instance.health;
    }

    public void GiveDamage()
    {
        int health = Mathf.Max(0, GetHealth() - 1);
        GameDataManager.Instance.health = health;
        FindObjectOfType<HealthManager>().UpdateText();
    }
}
