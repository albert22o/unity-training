using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class InheritParentColor : MonoBehaviour
{
    private Renderer parentRenderer;
    private Renderer myRenderer;

    void Start()
    {
        // Получаем рендерер родителя
        parentRenderer = transform.parent?.GetComponent<Renderer>();
        myRenderer = GetComponent<Renderer>();

        if (parentRenderer != null && parentRenderer.sharedMaterial != null)
        {
            // Создаем новый материал на основе родительского
            Material newMaterial = new Material(parentRenderer.sharedMaterial);
            myRenderer.material = newMaterial;
        }
    }

    void Update()
    {
        // Постоянное обновление цвета (если нужно)
        if (parentRenderer != null && myRenderer.material != null)
        {
            myRenderer.material.color = parentRenderer.material.color;
            myRenderer.enabled = parentRenderer.enabled;
        }
    }
}