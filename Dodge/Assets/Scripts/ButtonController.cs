using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    public AudioSource audioSource;
	public GameObject hpPanel;

    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void OpenSplashScene()
    {
        SceneManager.LoadScene("Splash");
    }
    public void TogglePlaySound()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }
    public void ToggleHpPanel()
    {
        if (hpPanel.activeSelf)
            hpPanel.SetActive(false);
        else
            hpPanel.SetActive(true);
    }
}
