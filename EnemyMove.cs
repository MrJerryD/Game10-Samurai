using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private float speed = 0.5f;

    private Transform target;

    private void Start()
    {
        // Начинаем движение к стартовой точке
        target = startPoint;
    }

    private void Update()
    {
        // Перемещаемся к цели
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Проверяем, достигли ли мы цели
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Меняем цель на противоположную точку
            if (target == startPoint)
            {
                target = endPoint;
            }
            else
            {
                target = startPoint;
            }

            // Поворачиваем персонажа
            FlipCharacter();
        }
    }

    // Метод для поворота персонажа
    private void FlipCharacter()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // Меняем знак масштаба по оси X, чтобы повернуть персонажа
        transform.localScale = newScale;
    }
}
