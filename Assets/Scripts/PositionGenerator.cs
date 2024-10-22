using UnityEngine;

public static class PositionGenerator
{
    public static Vector3 GetRandomPosition(float randomRadius)
    {
        // Создаем случайную позицию в пределах окружности радиусом randomRadius
        var randomPoint = Random.insideUnitCircle * randomRadius;
        return new Vector3(randomPoint.x, 0, randomPoint.y);
    }
}