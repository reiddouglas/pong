using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _Instance;
    public static MenuManager Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = new GameObject().AddComponent<MenuManager>();
            }
            return _Instance;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
}
