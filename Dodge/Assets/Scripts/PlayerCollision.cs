using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        var enemyHp=other.GetComponent<EnemyHp>();
        if (enemyHp)
            enemyHp.DamageHp(1);
    }
}
