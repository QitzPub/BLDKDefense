using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum LayerName
{
    Obstacle,
    InputAccepter,
}

public class LayerUtility
{
    static readonly int max = 32;

    static List<LayerMask> layerMasks = GetLayerMasks();
    static List<int> layers = GetLayers();

    public static LayerMask GetLayerMask(LayerName name)
    {
        return layerMasks[(int)name];
    }

    public static int GetLayerNumber(LayerName name)
    {
        return layers[(int)name];
    }

    static LayerMask FindLayerMask(LayerName name)
    {
        return 1 << Enumerable.Range(0, max)
            .Select(i => LayerMask.LayerToName(i))
            .Where(s => string.Compare(s, name.ToString(), true) == 0)
            .Select(s => LayerMask.NameToLayer(s))
            .FirstOrDefault();
    }

    static int FindLayerNumber(LayerName name)
    {
        return Enumerable.Range(0, max)
            .Select(i => LayerMask.LayerToName(i))
            .Where(s => string.Compare(s, name.ToString(), true) == 0)
            .Select(s => LayerMask.NameToLayer(s))
            .FirstOrDefault();
    }

    static List<LayerMask> GetLayerMasks()
    {
        var list = new List<LayerMask>();
        Enum.GetValues(typeof(LayerName)).Cast<LayerName>()
            .ToList()
            .ForEach(n => list.Add(FindLayerMask(n)));
        return list;
    }

    static List<int> GetLayers()
    {
        var list = new List<int>();
        Enum.GetValues(typeof(LayerName)).Cast<LayerName>()
            .ToList()
            .ForEach(n => list.Add(FindLayerNumber(n)));
        return list;
    }

}
