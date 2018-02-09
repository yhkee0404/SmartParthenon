using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {
	
	public Text hpText;
    public GameObject returnButton;
	public float growInterval = 5.0f;
    public int maxHp = 10;

    [SerializeField]
	private int hp;
	private float lastLogTime;

    public void HealHp(int amount)
    {
        hp += amount;
        if (hp > maxHp)
            hp = maxHp;
        UpdateHp();
    }
    public void DamageHp(int amount)
    {
        hp -= amount;
        UpdateHp();

        if (hp <= 0)
        {
            GetComponent<PlayerMove>().enabled = false;
            var enemySpawner = GameObject.Find("Enemy Spawner");
            enemySpawner.GetComponent<EnemySpawner>().enabled = false;
            foreach (Transform t in enemySpawner.transform.Cast<Transform>().ToArray())
            {
                t.GetComponent<EnemyMove>().enabled = false;
                t.GetComponent<EnemyExplosion>().enabled = false;
            }
            returnButton.SetActive(true);
        }
    }
    private void UpdateHp()
    {
		hpText.text = hp.ToString ();
    }
	private void Start()
	{
        hp = maxHp;
        lastLogTime = Time.time;
    }
	private void Update()
	{
        if (hp <= 0)
            enabled = false;
		else if (!Mathf.Approximately(growInterval, 0.0f) && Time.time - lastLogTime > growInterval)
		{
			lastLogTime = Time.time;
			HealHp(1);
		}
	}
}