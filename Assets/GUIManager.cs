using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    bool _paused = false;

    public bool Paused { get => _paused; set => _paused = value; }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        Paused = false;
    }
}
