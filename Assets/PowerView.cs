using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerView : MonoBehaviour
{
    [SerializeField] Text text;

    public void OnPowerChanged(int power)
    {
        text.text = power.ToString();
    }
}
