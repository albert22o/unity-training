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
    // ������ UI �������
    public void HideUI()
    {
        uiPanel.SetActive(false);
        pauseManager.ResumeGame();
    }

    // �������� UI �������
    public void ShowUI()
    {
        uiPanel.SetActive(true);
    }

    // ����������� ���������
    public void ToggleUI()
    {
        uiPanel.SetActive(!uiPanel.activeSelf);
    }
}