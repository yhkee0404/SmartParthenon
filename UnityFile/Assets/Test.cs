using System.Linq;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject cubePrefab;
    public float width = 10.0f;

    private void Start()
    {
        Debug.Log("Start()Hello World/");
    }

    [ContextMenu("Print Message")]//톱니바퀴 메뉴에 이 함수를 호출하는 옵션을 추가하여라
    void PrintMessage()
    {
        Debug.LogFormat("xxxx ---- {0}", width);   
    }

    [ContextMenu("Instantiate")]
    void InstantiatePrefab()
    {
        var newGameObject = Instantiate(cubePrefab);
        var tr = newGameObject.GetComponent<Transform>();
        tr.position = new Vector3(1, 2, 3);
        tr.localScale = new Vector3(1, 2, 3);
        //Instantiate(cubePrefab);
    }

    [ContextMenu("Instantiate Child")]
    void InstantiateChild()
    {
        var newGameObject = Instantiate(cubePrefab, transform);
        var tr = newGameObject.transform;
        tr.localPosition = new Vector3(1, 2, 3);
        //Instantiate(cubePrefab);
    }

    [ContextMenu("Destroy All")]
    void DestroyAllChildren()
    {
        //하이알키 상에서 하위에 있는 애들을 돌면서 뽑아내는 것 다만 여기에선 transform 자체를 뽑아내는 것인지라 .gameObject를 추가해주는 것이다.
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);//그 뽑아낸 걸 없애라.
        }
    }
}
/*콘솔 성정: clear on play, error pause를 눌러라(collapse는 해제)
 *  error-
 */