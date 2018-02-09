using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerHp playerHp;

    private void OnTriggerEnter(Collider other)
    {
		var enemyMove = other.transform.parent.GetComponent<EnemyMove>();
        if (enemyMove)
        {
            playerHp.DamageHp(1);
			var explosion = Instantiate (enemyMove.explosionPrefab);
			explosion.transform.position = enemyMove.transform.position;
			Destroy(enemyMove.gameObject);
        }
    }
}
