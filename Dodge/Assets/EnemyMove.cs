using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public GameObject player;
    public float speed;
    private float lastLogTime;
    public float destroyInterval;

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
        {
            Destroy(this.gameObject);
        }
    }
}
