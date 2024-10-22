using System.Linq;
using UnityEngine;

/// <summary>
/// Класс конфеты.
/// </summary>
public class Colorizer : MonoBehaviour
{
    [SerializeField] private int _randomRadius = 8;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _radius = 1;

    private ColorsProvider _colorsProvider;
    private Color _color;
    private Material _material;

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;

        // Сохраняем colored материал
        var materials = _renderer.materials;
        _material = materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));

        _color = _material.color;
    }

    private void Start()
    {
        SetRandomPosition();
        SetColor();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<Player>(out var player)) return;
        player.SetColor(_color);
        SetRandomPosition();
        SetColor();
    }

    private void SetRandomPosition()
    {
        var position = Vector3.zero;
        while (position.HasCollisions(_radius))
        {
            position = PositionGenerator.GetRandomPosition(_randomRadius);
        }

        transform.position = position;
    }

    private void SetColor()
    {
        var newColor = _colorsProvider.GetColor();

        _material.color = newColor;
        _color = newColor;
    }
}