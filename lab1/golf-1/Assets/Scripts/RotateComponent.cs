using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f; // градусов в секунду
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
