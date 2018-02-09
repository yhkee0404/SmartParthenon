using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public DirPad dirPad;
    public float speed = 10.0f;

    void Start()
    {
        dirPad = GameObject.Find("Dir Panel").GetComponent<DirPad>();
	}
    void Update ()
	{
        if (dirPad.dragging)
        {
            var dn = dirPad.dir.normalized * Time.deltaTime * speed;
            transform.Translate(new Vector3(dn.x, 0, dn.y));
        }
        else
        {
            var dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var dz = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(new Vector3(dx, 0, dz));
        }
        Vector3 movedPosition = transform.position;
        movedPosition.x = Mathf.Clamp(movedPosition.x, -50, 50);
        movedPosition.z = Mathf.Clamp(movedPosition.z, -50, 50);
    }
}
