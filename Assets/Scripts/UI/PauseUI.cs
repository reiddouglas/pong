using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private OptionsUI optionsUI;

    private void OnEnable()
    {
        optionsUI.OnOptionsClosed += CloseOptions;
    }

    private void OnDisable()
    {
        optionsUI.OnOptionsClosed -= CloseOptions;
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Game resumed");
    }

    public void OpenOptions()
    {
        gameObject.SetActive(false);
        optionsUI.gameObject.SetActive(true);
    }

    public void CloseOptions()
    {
        gameObject.SetActive(true);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Debug.Log("Quit to main menu");
        SceneManager.LoadSceneAsync("MenuScene");
    }
}
