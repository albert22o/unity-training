using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // ������������� ������� �����
    public void ReloadCurrentScene()
    {
        // �������� ������ ������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ��������� ����� � ���� ��������
        SceneManager.LoadScene(currentSceneIndex);
    }

    // ������������ �� ������� ������� (��� ������������)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentScene();
        }
    }
}