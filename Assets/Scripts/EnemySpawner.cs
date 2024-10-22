using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Класс, создающий врагов на сцене.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private int _enemiesCount = 6;
    [SerializeField] private int _randomRadius = 8;
    [SerializeField] private float _enemyRadius = 1;
    [SerializeField] private Player _player;
    private ColorsProvider _colorsProvider;

    private readonly Dictionary<Color, int> _countOtherColors = new();
    private readonly List<Color> _colors = new();

    private int _countRedEnemy;
    private int _countGreenEnemy;
    private int _countBlueEnemy;

    private int _temp;
    private Color[] _allColors;
    public Action<int, int, int> ControlCountColorsEnemy;


    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;

        for (var i = 0; i < _enemiesCount; i++)
        {
            var position = PositionGenerator.GetRandomPosition(_randomRadius);

            while (position.HasCollisions(_enemyRadius))
            {
                position = PositionGenerator.GetRandomPosition(_randomRadius);
            }

            var enemy = Instantiate(_enemyPrefab);
            enemy.transform.position = position;
            enemy.Initialize(_colorsProvider.GetColor());

            _colors.Add(enemy._color);
        }

        _allColors = _colorsProvider.GetAllColors();
        foreach (var color in _allColors)
        {
            _countOtherColors.Add(color, 0);
        }

        foreach (var color in _colors.Where(color => _countOtherColors.ContainsKey(color)))
        {
            _countOtherColors[color] += 1;
        }

        ChangeCountColorsPresent();
    }


    private void Start()
    {
        ControlCountColorsEnemy?.Invoke(_countRedEnemy, _countGreenEnemy, _countBlueEnemy);
        _temp = _enemiesCount;
    }

    private void Update()
    {
        var presents = GameObject.FindGameObjectsWithTag("Present");
        if (presents.Length >= _temp) return;
        _countOtherColors[_player.GetColor()] -= 1;
        ChangeCountColorsPresent();

        _temp--;
    }

    private void ChangeCountColorsPresent()
    {
        _countRedEnemy = _countOtherColors[_allColors[0]];
        _countGreenEnemy = _countOtherColors[_allColors[1]];
        _countBlueEnemy = _countOtherColors[_allColors[2]];
        ControlCountColorsEnemy?.Invoke(_countRedEnemy, _countGreenEnemy, _countBlueEnemy);
    }
}