using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static bool HasCollisions(this Vector3 position, float radius)
    {
        // В Unity, трансформ объектов и реальное положение коллайдеров иногда могут не синхронизироваться
        // из-за оптимизаций и особенностей работы физического движка.
        // Это может привести к временным несоответствиям между тем, где находится объект (согласно его трансформу)
        // и где находится его коллайдер с точки зрения физического движка.
        // Вызов Physics.SyncTransforms() принудительно синхронизирует эти два представления,
        // гарантируя, что положение коллайдеров в физическом мире соответствует трансформу их объектов.
        Physics.SyncTransforms();
        
        // Создаем сферу на заданной позиции заданным радиусом и получаем все коллайдеры, с которыми пересеклась сфера
        var colliders = Physics.OverlapSphere(position, radius);

        // Исключаем коллайдер пола
        var collidersExceptGameBoard =
            colliders.Where(currentCollider => !currentCollider.CompareTag(GlobalConstants.GAME_BOARD_TAG)).ToList();

        // Если хоть 1 колаайдер пересекли - вернем true
        return collidersExceptGameBoard.Any();
    }
}