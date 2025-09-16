using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private Arrow Arrow;

    public void TogglePause()
    {
        isPaused = !isPaused; // Меняем состояние паузы на противоположное

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Arrow.GetComponent<Renderer>().enabled = false; 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Arrow.GetComponent<Renderer>().enabled = false;
    }
}