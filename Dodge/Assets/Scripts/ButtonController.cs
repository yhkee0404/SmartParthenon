using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public AudioSource mainAudioSource;
    public AudioSource clickAudioSource;
    public GameObject hpPanel;

    private Score score;

    public void OpenMainScene()
    {
        clickAudioSource.Play();
        SceneManager.LoadScene("Main");
    }
    public void OpenSplashScene()
    {
        clickAudioSource.Play();
        score.SaveScore();
        SceneManager.LoadScene("Splash");
    }
    public void TogglePlaySound()
    {
        clickAudioSource.Play();
        if (mainAudioSource.isPlaying)
            mainAudioSource.Pause();
        else
            mainAudioSource.Play();
    }
    public void ToggleHpPanel()
    {
        clickAudioSource.Play();
        hpPanel.SetActive(!hpPanel.activeSelf);
    }

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
}
