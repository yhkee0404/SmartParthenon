using UnityEngine;

public class Move : MonoBehaviour {
    //Rigidbody rb;
    public float speed = 1;
    public DirPad dirPad;

    void Start () {
        Debug.Log("Start() called.");
	}
	void Update () {
        if (dirPad.dragging) {
            var dn = dirPad.dir.normalized * Time.deltaTime * speed;
            transform.Translate(new Vector3(dn.x, 0, dn.y));
        } else {
            Debug.LogFormat("Time.deltaTime = {0}", Time.deltaTime);
            var dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var dz = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(new Vector3(dx, 0, dz));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("OnTriggerEnter called. other is {0}", other.name);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.LogFormat("OnTriggerExit called. other is {0}", other.name);
    }
}
