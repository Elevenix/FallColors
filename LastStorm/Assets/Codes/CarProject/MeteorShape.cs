using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MeteorShape : MonoBehaviour
{
    [SerializeField]
    private SpriteShapeController shape;

    [SerializeField]
    private int minCountEdge, maxCountEdge;

    [SerializeField]
    private float minSize, maxSize;

    // Start is called before the first frame update
    void Awake()
    {
        shape.spline.Clear();

        int countEdge = Random.Range(minCountEdge, maxCountEdge+1);
        for (int i = 0; i<countEdge; i++)
        {
            float angle = (360 / (countEdge)) * i;
            angle = angle * Mathf.PI / 180f;
            Vector3 posEdge = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
            float randSize = Random.Range(minSize, maxSize);
            shape.spline.InsertPointAt(i,posEdge.normalized * randSize);
        }
    }

}
