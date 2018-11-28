using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] Text text;

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = GameDataManager.Instance.Money.ToString();
    }
}
