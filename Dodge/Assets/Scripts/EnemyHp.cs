using UnityEngine;

public class EnemyHp : MonoBehaviour {
    
	public float growInterval = 0.0f;
    public int maxHp = 10;

    private GameObject childGameObject;
    [SerializeField]
    private int hp;
    private float lastLogTime;

    public void HealHp(int amount)
    {
        hp += amount;
        if (hp > maxHp)
            hp = maxHp;
    }
    public void DamageHp(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            childGameObject.SetActive(false);
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<EnemyExplosion>().enabled = true;
        }
    }
    private void Start()
    {
        childGameObject = transform.GetChild(0).gameObject;

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