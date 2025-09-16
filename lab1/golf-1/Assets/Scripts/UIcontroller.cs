using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private PauseManager pauseManager;
    private void OnTriggerEnter(Collider other)
    {
       uiPanel.SetActive(true);
       pauseManager.PauseGame();
    }
    // Скрыть UI элемент
    public void HideUI()
    {
        uiPanel.SetActive(false);
        pauseManager.ResumeGame();
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