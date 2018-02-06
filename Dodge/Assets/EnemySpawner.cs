using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private float lastLogTime;
    public float spawnRadius;
    public float spawnInterval;
    public GameObject enemyPrefab;
    public GameObject player;
    public float enemySpeed;

    private void Start()
    {
        player = GameObject.Find("Player");

        lastLogTime = 0.0f;
    }

    // Update is called once per frame
    void Update () {
        if (Time.time - lastLogTime > spawnInterval)
        {
            lastLogTime = Time.time;
            Spawn();
        }
	}

    private void Spawn()
    {
        var enemy = Instantiate(enemyPrefab);
        var theta = Random.Range(0, 2 * Mathf.PI);
        var spawnPos = spawnRadius * new Vector3(Mathf.Cos(theta), 0, Mathf.Sin(theta));
        enemy.transform.position = player.transform.position + spawnPos;
        enemy.GetComponent<EnemyMove>().speed = enemySpeed;
        enemy.GetComponent<EnemyMove>().player = player;
    }
}
