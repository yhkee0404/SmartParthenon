using UnityEngine;

public class EnemyExplosion : MonoBehaviour {
    
    public GameObject explosionPrefab;
    public float explosionInterval = 0.5f;

    private AudioSource audioSource;
    private Score score;
    private GameObject childGameObject;
    private PlayerHp playerHp;
    private float lastLogTime;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        childGameObject = transform.GetChild(0).gameObject;
        playerHp = GameObject.Find("Player").GetComponent<PlayerHp>();
        
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    private void OnEnable()
    {
        lastLogTime = Time.time;
    }
    private void Update () {
        if (childGameObject.activeSelf)
        {
            if (Time.time - lastLogTime > explosionInterval)
            {
                score.IncreaseScore(1);
                playerHp.DamageHp(1);

                var explosion = Instantiate(explosionPrefab);
                audioSource.Play();
                explosion.transform.position = childGameObject.transform.position;
                
                lastLogTime = Time.time;
            }
        }
        else if (!audioSource.isPlaying)
            Destroy(gameObject);
    }
}
