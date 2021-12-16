using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool gameIsPaused;
    public AudioClip musicaFundo;
    public AudioClip tiroPlayer;
    public AudioClip comecoLevel;
    public AudioClip fimLevel;

    public AudioSource audioSourceComecoLevel;
    public AudioSource audioSourceTiroPlayer;
    public AudioSource audioSourceMusicaFundo;
    public AudioSource audioSourceFimLevel;

    public GameObject completeGameUI;

    // Start is called before the first frame update
    void Start()
    {
        playComeco();
        playMusicBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            audioSourceMusicaFundo.Pause();
        }
        else
        {
            Time.timeScale = 1;
            audioSourceMusicaFundo.UnPause();
        }
    }

    public void playComeco()
    {
        audioSourceComecoLevel.clip = comecoLevel;
        audioSourceComecoLevel.Play();
    }

    public void playMusicBackground()
    {
        audioSourceMusicaFundo.clip = musicaFundo;
        audioSourceMusicaFundo.Play();
    }

    public void playAudioTiro()
    {
        audioSourceTiroPlayer.clip = tiroPlayer;
        audioSourceTiroPlayer.Play();
    }

    public void playFimLevel()
    {
        audioSourceFimLevel.PlayOneShot(fimLevel, 0.4f);
    }

    public void CompleteLevel()
    {
        completeGameUI.SetActive(true);
        audioSourceMusicaFundo.Pause();
        playFimLevel();
    }
}