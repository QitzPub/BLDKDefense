using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHolder : SingletonMonoBehaviour<PrefabHolder>
{
    public RoseTween roundRose;
    public GameObject straightRose;

    public GameObject waveAnimation;
    public GameObject failAnimation;
    public TitleManager titleManager;
    public GameObject titleDisplay;
    public GameObject clearAnimation;

    public OpeningRoseTween openingRose;
    public EndingAnimation endingRose;

    new void Awake()
    {
        base.Awake();
    }

}
