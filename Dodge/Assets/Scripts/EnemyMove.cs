using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public GameObject player;
    public GameObject explosionPrefab;
    public float speed;
    public float destroyInterval;
    private float lastLogTime;

    private void Start()
    {
        lastLogTime = Time.time;
    }

    void Update()
    {
        var diff = player.transform.position - transform.position;
        var dir = diff.normalized;
        transform.Translate(dir * Time.deltaTime * speed);
        
        if (Time.time - lastLogTime > destroyInterval)
            Destroy(gameObject);
    }
    private void OnDestroy()
    {
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
