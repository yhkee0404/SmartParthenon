using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {
	
	public GameObject hpPanel;
	public int initialHp = 10;
	public float growInterval = 0.0f;
	private int hp;
	private float lastLogTime;

	public void ResetHp()
	{
		hp = initialHp;
		UpdateHp ();
	}
    public void HealHp(int amount)
    {
        hp += amount;
        UpdateHp();
    }
    public void DamageHp(int amount)
    {
        hp -= amount;
		UpdateHp ();

		if (hp <= 0)
		{
			Destroy (GetComponentInParent<EnemyMove> ());
			Destroy(GameObject.Find("Enemy Spawner"));
		}
    }

    private void UpdateHp()
    {
		if (hpPanel.activeSelf)
			hpPanel.transform.Find ("Hp Text").GetComponent<Text> ().text = hp.ToString ();

        PlayerPrefs.SetInt("PLAYER_HP", hp);
        PlayerPrefs.Save();
    }
	private void Start()
	{
		lastLogTime = 0.0f;

		hp = PlayerPrefs.GetInt("PLAYER_HP", initialHp);
		if (hp <= initialHp)
			ResetHp ();
		
		UpdateHp ();
	}
	private void Update()
	{
		if (!Mathf.Approximately(growInterval, 0.0f) && Time.time - lastLogTime > growInterval)
		{
			lastLogTime = Time.time;
			HealHp(1);
		}
	}
}