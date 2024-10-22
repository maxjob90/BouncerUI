using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Класс, содержащий информацию о всех цветах в игре.
/// </summary>
[Serializable]
public class ColorsProvider
{
    [SerializeField] private Color[] _colors;

    public Color GetColor()
    {
        var index = Random.Range(0, _colors.Length);
        return _colors[index];
    }

    public Color[] GetAllColors()
    {
        return _colors;
    }
}