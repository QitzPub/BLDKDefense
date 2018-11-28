using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] string prefix;

    void Start()
    {
        UpdateText();
    }

    public string UpdateText()
    {
        return text.text = prefix + " " + (GameDataManager.Instance.selectedLevel + 1);
    }

}
