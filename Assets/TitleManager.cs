using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System;

public class TitleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> terrains;
    [SerializeField] float terrainDistance;
    [SerializeField] float terrainTweenDuration;
    [SerializeField] float terrainTotalDuration;

    [SerializeField] List<GameObject> accessories;
    [SerializeField] float accessoryDistance;
    [SerializeField] float accessoryTweenDuration;
    [SerializeField] float accessoryTotalDuration;

    [SerializeField] GameObject character;
    [SerializeField] float characterDistance;
    [SerializeField] float characterTweenDuration;
    [SerializeField] float characterDelay;

    bool isLoading;

    public void Animate()
    {
        var title = (Instantiate(PrefabHolder.Instance.titleDisplay) as GameObject).GetComponentInChildren<TextDisplay>();
        title.Play("");

        terrains = terrains
            .OrderBy(t => Guid.NewGuid())
            .ToList();
        int numberTerrains = terrains.Count;
        for (int i = 0; i < numberTerrains; i++)
        {
            terrains[i].transform
                       .DOLocalMoveY(-terrainDistance, terrainTweenDuration)
                       .From()
                       .SetDelay(terrainTotalDuration / numberTerrains * i);
        }

        accessories = accessories
            .OrderBy(t => Guid.NewGuid())
            .ToList();

        int numberAccessories = accessories.Count;
        for (int i = 0; i < numberAccessories; i++)
        {
            accessories[i].transform
                       .DOLocalMoveY(accessoryDistance, accessoryTweenDuration)
                       .From()
                       .SetDelay(accessoryTotalDuration / numberAccessories * i);
        }

        character.transform
                 .DOLocalMoveY(characterDistance, characterTweenDuration)
                 .From()
                 .SetDelay(characterDelay)
                 .SetEase(Ease.InQuad);
    }

    void Update()
    {
        if (isLoading == false && Input.anyKey)
        {
            isLoading = true;
            SceneInitializer.Instance.InitializeScene(SceneType.Level);
        }
    }
}
