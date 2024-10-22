using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField] private PlayerMovementController _movementController;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _movementController.ControlCountClickMouse += _uiManager.SetClickMouse;
        _enemySpawner.ControlCountColorsEnemy += _uiManager.SetCountColorEnemy;
    }

    private void OnDestroy()
    {
        _movementController.ControlCountClickMouse -= _uiManager.SetClickMouse;
        _enemySpawner.ControlCountColorsEnemy -= _uiManager.SetCountColorEnemy;
    }
}