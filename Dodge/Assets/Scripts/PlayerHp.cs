using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {
    private int hp;
    private GameObject hpPanel;
    private float lastLogTime;
    public float growInterval;
    public void HealHp(int amount)
    {
        hp += amount;
        UpdateHp();
    }
    public void DamageHp(int amount)
    {
        hp -= amount;
        UpdateHp();

        if (hp <= 0)
            Destroy(gameObject);
    }
    private void UpdateHp()
    {
        if (hpPanel.activeSelf)
            hpPanel.GetComponentInChildren<Text>().text = hp.ToString();

        PlayerPrefs.SetInt("PLAYER_HP", hp);
        PlayerPrefs.Save();
    }
    private void Start()
    {
        lastLogTime = 0.0f;
    }

    private void Update()
    {
        if (Time.time - lastLogTime > growInterval)
        {
            lastLogTime = Time.time;
            HealHp(1);
        }
    }
}
