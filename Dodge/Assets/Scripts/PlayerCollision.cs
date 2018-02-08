using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private PlayerHp playerHp;

    private void Start()
    {
        playerHp = transform.parent.GetComponent<PlayerHp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.transform.parent;
        if (enemy.GetComponent<EnemyMove>())
        {
            playerHp.DamageHp(1);
            Destroy(enemy.gameObject);
        }
    }
}
