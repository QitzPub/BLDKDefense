using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPowerManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float maxPower;
    [SerializeField] float speed;

    void Awake()
    {
        slider.maxValue = maxPower;
        slider.value = maxPower;
    }

    private void Update()
    {
        GameDataManager.Instance.UnitPower = Mathf.Min(GameDataManager.Instance.UnitPower + speed * Time.deltaTime, maxPower);
        UpdateUnitPower();
    }

    void UpdateUnitPower()
    {
        slider.value = GameDataManager.Instance.UnitPower;
    }
}
