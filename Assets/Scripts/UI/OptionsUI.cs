using UnityEngine;
using System;

public class OptionsUI : MonoBehaviour
{

    public event Action OnOptionsClosed;

    public void Apply()
    {
        // save options to options manager
    }

    public void Close()
    {
        gameObject.SetActive(false);
        OnOptionsClosed?.Invoke();
    }
}
