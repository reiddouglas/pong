using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Game resumed");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Debug.Log("Quit to main menu");
        SceneManager.LoadSceneAsync("MenuScene");
    }
}
