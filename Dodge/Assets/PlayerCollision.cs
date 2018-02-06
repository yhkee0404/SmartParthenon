using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerHP playerHP;

    private void OnTriggerEnter(Collider other)
    {
        playerHP.hp--;
        Destroy(other.gameObject);
    }
}
