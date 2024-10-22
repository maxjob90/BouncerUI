using System;
using UnityEngine;

/// <summary>
/// Класс, отвечающий за передвижение кубика.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _forceValue = 250;

    private Rigidbody _rigidbody;
    private Vector3 _target;
    private Camera _camera;

    public Action<int> ControlCountClickMouse;
    private int _сountСlickMouse;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        // Создаем луч из позиции мыши
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hitInfo)) return;
        // Зануляем скорость
        _rigidbody.linearVelocity = Vector3.zero;
        // Двигаем кубик к заданной точке
        MoveTowardsSelectedPoint(hitInfo);
        ControlCountClickMouse?.Invoke(_сountСlickMouse);
    }

    private void MoveTowardsSelectedPoint(RaycastHit hitInfo)
    {
        ClickMouse();
        // Вычисляем направление движения
        var direction = (hitInfo.point - transform.position).normalized;

        _rigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * _forceValue);
    }

    private void ClickMouse()
    {
        ControlCountClickMouse?.Invoke(++_сountСlickMouse);
    }
}