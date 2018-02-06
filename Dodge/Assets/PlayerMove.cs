using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public DirPad dirPad;
    public float speed = 1.0f;

    void Start()
    {
        dirPad = GameObject.Find("Dir Panel").GetComponent<DirPad>();
}
    // Update is called once per frame
    void Update () {
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
    }
}
