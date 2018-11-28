using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Text text;

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = ObjectManager.Instance.Goal.GetHealth().ToString();
    }
}
