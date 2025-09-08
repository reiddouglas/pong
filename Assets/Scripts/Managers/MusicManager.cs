using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _Instance;
    public static MusicManager Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
