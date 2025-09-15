using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("References")]
    public Transform sphere; // Ваша сфера
    public Camera mainCamera; // Основная камера

    [Header("Settings")]
    public float arrowDistance = 1.5f; // Дистанция от сферы
    public float rotationSpeed = 8f; // Скорость поворота
    public bool lockZRotation = true; // Блокировать вращение по Z
    public Vector3 _direction;
    [Header("Colors")]
    public Color activeColor = Color.yellow; // Цвет когда активно
    public Color inactiveColor = Color.white; // Цвет когда неактивно

    private Renderer arrowRenderer;
    private Material originalMaterial;
    private Material coloredMaterial;
    void Update()
    {
        if (sphere == null || mainCamera == null) return;

        // Получаем позицию курсора в мировых координатах
        Vector3 mouseWorldPos = GetMouseWorldPosition();

        // Направление от сферы к курсору (игнорируем Y если нужно)
        _direction = (mouseWorldPos - sphere.position).normalized;

        // Позиция стрелки
        transform.position = sphere.position + _direction * arrowDistance;

        // Поворот стрелки
        RotateArrowTowardsCursor(_direction);
    }
    void Start()
    {
        // Получаем рендерер текущего объекта (стрелки)
        arrowRenderer = GetComponent<Renderer>();

        // Сохраняем оригинальный материал
        if (arrowRenderer != null)
        {
            originalMaterial = arrowRenderer.material;

            // Создаем новый материал для цветного состояния
            coloredMaterial = new Material(originalMaterial);
            coloredMaterial.color = activeColor;
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        // Создаем луч от камеры к курсору
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Создаем плоскость на уровне сферы (параллельную камере)
        Plane plane = new Plane(-mainCamera.transform.forward, sphere.position);

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return sphere.position + Vector3.right * 10f; // Fallback позиция
    }

    private void RotateArrowTowardsCursor(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            // Создаем поворот только по оси Z (для 2D вида)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (lockZRotation)
            {
                // Только поворот по Z, остальные оси фиксированы
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    rotationSpeed * Time.deltaTime);
            }
            else
            {
                // Полный 3D поворот, но с учетом камеры
                Quaternion targetRotation = Quaternion.LookRotation(direction, mainCamera.transform.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    rotationSpeed * Time.deltaTime);
            }
        }
    }

    // Визуализация в редакторе
    void OnDrawGizmosSelected()
    {
        if (sphere != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(sphere.position, transform.position);
        }
    }

    internal void Set_active(bool v)
    {
        if (arrowRenderer != null)
        {
            // Переключаем между материалами
            if (v)
            {
                arrowRenderer.material = coloredMaterial;
            }
            else
            {
                arrowRenderer.material = originalMaterial;
            }
        }
    }
}