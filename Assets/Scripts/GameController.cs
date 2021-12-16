using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool gameIsPaused;
    public AudioClip musicaFundo;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = musicaFundo;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            audioSource.Pause();
        }
        else
        {
            Time.timeScale = 1;
            audioSource.UnPause();
        }
    }
}
