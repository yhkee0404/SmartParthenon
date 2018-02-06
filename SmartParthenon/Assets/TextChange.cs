using UnityEngine;
using UnityEngine.UI;
public class TextChange : MonoBehaviour {
    public Text testText;
	void Start () {
	}
	void Update () {
        testText.text = string.Format("프레임번호:{0}", Time.frameCount);
        testText.fontSize = 20;
	}
}
