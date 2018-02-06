using System.Linq;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public GameObject cubePrefab;
    public float width = 2.0f;
    public float height = 0.7f;

    [ContextMenu("Build")]
    void TowerBuild()
    {
        var tr = transform;
        var newGameObject = tr. gameObject;

        newGameObject = Instantiate(cubePrefab, tr);
        tr = newGameObject.transform;
        tr.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
        tr.localScale = new Vector3(width, height, width);

        GameObject newGameObject2;
        for ( int i= 0; i< 2; i++)
        {
            newGameObject2 = Instantiate(newGameObject, tr);
            tr.localPosition = new Vector3(0.0f, 0.7f, 0.0f);
            tr.localScale = new Vector3(0.9f, 1.0f, 0.9f);

            newGameObject = newGameObject2;
        }
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
