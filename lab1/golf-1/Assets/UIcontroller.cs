using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel; // Перетащите ваш UI элемент в Inspector

    private void OnTriggerEnter(Collider other)
    {
       uiPanel.SetActive(true);
    }
    // Скрыть UI элемент
    public void HideUI()
    {
        uiPanel.SetActive(false);
    }

    // Показать UI элемент
    public void ShowUI()
    {
        uiPanel.SetActive(true);
    }

    // Переключить видимость
    public void ToggleUI()
    {
        uiPanel.SetActive(!uiPanel.activeSelf);
    }
}