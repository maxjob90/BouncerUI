using UnityEngine;

/// <summary>
/// Контроллер игры, содержащий ссылку на ColorsProvider и инициализирующий EnemySpawner и SphereController.
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private ColorsProvider _colorsProvider;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Colorizer _colorizer;


    private void Awake()
    {
        _enemySpawner.Initialize(_colorsProvider);
        _colorizer.Initialize(_colorsProvider);
    }
}