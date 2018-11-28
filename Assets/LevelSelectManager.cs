using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    List<LevelTile> tiles;
    void Awake()
    {
        tiles = GetComponentsInChildren<LevelTile>().ToList();
    }

    public void UpdateSelectedLevel(LevelTile levelTile)
    {
        Enumerable.Range(0, tiles.Count)
            .ToList()
            .ForEach(i => {
                if(tiles[i].GetInstanceID() == levelTile.GetInstanceID())
                {
                    GameDataManager.Instance.selectedLevel = i;
                    return;
                }
            });
    }
}
