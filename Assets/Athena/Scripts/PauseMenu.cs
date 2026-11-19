using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject pauseMenu;
    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);

        Time.timeScale = 0;
    }
    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);

        Time.timeScale = 1;
    }

    public void Toggle(InputAction.CallbackContext ctx)
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
