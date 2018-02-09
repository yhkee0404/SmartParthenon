using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public Text scoreText;
	private int score;
    
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScore();
    }
    public void SaveScore()
    {
        Debug.LogFormat("{0}", score);
        PlayerPrefs.SetInt("SCORE", score);
        PlayerPrefs.Save();
    }
    
    private void UpdateScore()
    {
		scoreText.text = score.ToString ();
    }
	private void Start()
	{
        score = PlayerPrefs.GetInt("SCORE", 0);
        scoreText.text = score.ToString();
    }
}