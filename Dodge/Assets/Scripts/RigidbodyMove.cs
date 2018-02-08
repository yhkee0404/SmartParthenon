using UnityEngine;

public class RigidbodyMove : MonoBehaviour {
    Rigidbody rb;
    public float speed = 10;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var dx = Input.GetAxis("Horizontal");
        var dz = Input.GetAxis("Vertical");
        var inputDir = new Vector3(dx, 0, dz).normalized;
        //rb.AddForce(new Vector3(dx, 0, dz) * forceMag);
        rb.velocity = new Vector3(inputDir.x * speed, rb.velocity.y, inputDir.z * speed);
        Debug.LogFormat("Velocity: {0}", rb.velocity.magnitude);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
