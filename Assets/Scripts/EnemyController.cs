using System.Linq;
using UnityEngine;

/// <summary>
/// Класс врага - цилиндра.
/// </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private Material _material;
    public Color _color;

    public void Initialize(Color color)
    {
        var materials = _renderer.materials;
        _material = materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));

        _material.color = color;
        _color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        if (player.Color == _color)
        {
            Destroy(gameObject);
        }
    }
}