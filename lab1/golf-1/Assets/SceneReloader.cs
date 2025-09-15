using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // Перезагрузить текущую сцену
    public void ReloadCurrentScene()
    {
        // Получаем индекс текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Загружаем сцену с этим индексом
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Перезагрузка по нажатию клавиши (для тестирования)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentScene();
        }
    }
}