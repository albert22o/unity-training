using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class InheritParentColor : MonoBehaviour
{
    private Renderer parentRenderer;
    private Renderer myRenderer;

    void Start()
    {
        // �������� �������� ��������
        parentRenderer = transform.parent?.GetComponent<Renderer>();
        myRenderer = GetComponent<Renderer>();

        if (parentRenderer != null && parentRenderer.sharedMaterial != null)
        {
            // ������� ����� �������� �� ������ �������������
            Material newMaterial = new Material(parentRenderer.sharedMaterial);
            myRenderer.material = newMaterial;
        }
    }

    void Update()
    {
        // ���������� ���������� ����� (���� �����)
        if (parentRenderer != null && myRenderer.material != null)
        {
            myRenderer.material.color = parentRenderer.material.color;
            myRenderer.enabled = parentRenderer.enabled;
        }
    }
}