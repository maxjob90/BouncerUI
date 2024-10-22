using System.Linq;
using UnityEngine;

/// <summary>
/// Класс игрока, содержащий информацию о цвете игрока.
/// </summary>
public class Player : MonoBehaviour
{
    public Color Color { get; private set; }
    [SerializeField] private Renderer _renderer;
    private Material _material;

    private void Awake()
    {
        var materials = _renderer.materials;
        _material = materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));
    }

    public void SetColor(Color color)
    {
        _material.color = color;
        Color = color;
    }

    public Color GetColor()
    {
        return Color;
    }
}