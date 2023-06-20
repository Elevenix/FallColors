using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LandShape : MonoBehaviour
{
    [SerializeField]
    private SpriteShapeController shape;

    [SerializeField]
    private float startEdge, sizeEdge, heightDown, cornerPosX;

    [SerializeField]
    private int minEdgeCountBy100, maxEdgeCountBy100;

    [SerializeField]
    private Vector2 randHeight;

    // Start is called before the first frame update
    void Awake()
    {

        //startEdge + sizeEdge/2
        this.transform.position = new Vector3(startEdge, this.transform.position.y, this.transform.position.z);

        SetStartPointPosition(startEdge - transform.position.x);

        int randCount = Random.Range( (int)(minEdgeCountBy100 * (sizeEdge / 100)), (int)(maxEdgeCountBy100 * (sizeEdge / 100)));
        float dist = shape.spline.GetPosition(1).x - shape.spline.GetPosition(0).x;
        float distEdge = dist / (randCount);

        // create all the edges
        for (int i = 1; i < randCount; i++){
            float height = Random.Range(randHeight.x, randHeight.y);
            shape.spline.InsertPointAt(i,new Vector3(shape.spline.GetPosition(0).x + (distEdge *i), height ,0));
            SetTangentSpline(shape.spline, i, distEdge);
        }

    }

    // set the principal point
    private void SetStartPointPosition(float x)
    {
        shape.spline.SetPosition(0, new Vector3(x, 0, this.transform.position.z));
        shape.spline.SetPosition(1, new Vector3(x + sizeEdge, 0, this.transform.position.z));
        if(shape.spline.GetPointCount() > 2)
        {
            shape.spline.SetPosition(3, new Vector3(x - cornerPosX, heightDown, this.transform.position.z));
            shape.spline.SetPosition(2, new Vector3(x + sizeEdge + cornerPosX, heightDown, this.transform.position.z));
        }
    }

    // Set the tangent mode and the arcs
    private void SetTangentSpline(Spline sp, int index, float distEdge)
    {
        sp.SetTangentMode(index, ShapeTangentMode.Continuous);
        sp.SetLeftTangent(index, new Vector3(-distEdge/2, 0, 0));
        sp.SetRightTangent(index, new Vector3(distEdge/2, 0, 0));
    }

    public void SetStartShape(float startEdge, float sizeEdge)
    {
        this.startEdge = startEdge;
        this.sizeEdge = sizeEdge;
    }

    public void SetParameters(int minEdge, int maxEdge, Vector2 randH)
    {
        minEdgeCountBy100 = minEdge;
        maxEdgeCountBy100 = maxEdge;
        randHeight = randH;
    }

    public float GetSizeEdge()
    {
        return sizeEdge;
    }

    public float GetStartEdge()
    {
        return this.startEdge;
    }
}
