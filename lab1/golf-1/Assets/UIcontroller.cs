using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel; // ���������� ��� UI ������� � Inspector

    private void OnTriggerEnter(Collider other)
    {
       uiPanel.SetActive(true);
    }
    // ������ UI �������
    public void HideUI()
    {
        uiPanel.SetActive(false);
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