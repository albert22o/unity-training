using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("References")]
    public Transform sphere; // ���� �����
    public Camera mainCamera; // �������� ������

    [Header("Settings")]
    public float arrowDistance = 1.5f; // ��������� �� �����
    public float rotationSpeed = 8f; // �������� ��������
    public bool lockZRotation = true; // ����������� �������� �� Z
    public Vector3 _direction;
    [Header("Colors")]
    public Color activeColor = Color.yellow; // ���� ����� �������
    public Color inactiveColor = Color.white; // ���� ����� ���������

    private Renderer arrowRenderer;
    private Material originalMaterial;
    private Material coloredMaterial;
    void Update()
    {
        if (sphere == null || mainCamera == null) return;

        // �������� ������� ������� � ������� �����������
        Vector3 mouseWorldPos = GetMouseWorldPosition();

        // ����������� �� ����� � ������� (���������� Y ���� �����)
        _direction = (mouseWorldPos - sphere.position).normalized;

        // ������� �������
        transform.position = sphere.position + _direction * arrowDistance;

        // ������� �������
        RotateArrowTowardsCursor(_direction);
    }
    void Start()
    {
        // �������� �������� �������� ������� (�������)
        arrowRenderer = GetComponent<Renderer>();

        // ��������� ������������ ��������
        if (arrowRenderer != null)
        {
            originalMaterial = arrowRenderer.material;

            // ������� ����� �������� ��� �������� ���������
            coloredMaterial = new Material(originalMaterial);
            coloredMaterial.color = activeColor;
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        // ������� ��� �� ������ � �������
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // ������� ��������� �� ������ ����� (������������ ������)
        Plane plane = new Plane(-mainCamera.transform.forward, sphere.position);

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return sphere.position + Vector3.right * 10f; // Fallback �������
    }

    private void RotateArrowTowardsCursor(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            // ������� ������� ������ �� ��� Z (��� 2D ����)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (lockZRotation)
            {
                // ������ ������� �� Z, ��������� ��� �����������
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    rotationSpeed * Time.deltaTime);
            }
            else
            {
                // ������ 3D �������, �� � ������ ������
                Quaternion targetRotation = Quaternion.LookRotation(direction, mainCamera.transform.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    rotationSpeed * Time.deltaTime);
            }
        }
    }

    // ������������ � ���������
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
            // ����������� ����� �����������
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