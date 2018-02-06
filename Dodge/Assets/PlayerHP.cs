using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    public float hp = 10.0f;
    private Text hpText;
    private float lastLogTime;
    public float growInterval= 5.0f;
    public GameObject endPanelPrefab;

    private void Start()
    {
        hpText = GameObject.Find("HP Text").GetComponent<Text>();

        lastLogTime = 0.0f;
    }

    private void Update()
    {
        hpText.text = hp.ToString();

        if (Time.time - lastLogTime > growInterval)
        {
            lastLogTime = Time.time;
            hp++;
        }
        if (hp <= 0)
            Destroy(this.gameObject);
    }
}
