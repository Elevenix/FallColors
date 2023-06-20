using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpawnerObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    [SerializeField]
    private SpriteShapeController shape;

    [SerializeField]
    private int minCountBy100, maxCountBy100;

    [SerializeField]
    private float minPosZ, maxPosZ;

    [SerializeField]
    private bool personalRotation = false;

    private int countEdge;
    // Start is called before the first frame update
    void Start()
    {
        countEdge = shape.spline.GetPointCount() - 3;
        float sizeEdge = shape.GetComponent<LandShape>().GetSizeEdge();
        int nbr = Random.Range((int)(minCountBy100 * (sizeEdge/100)), (int)(maxCountBy100 * (sizeEdge/100)));
        LoopSpawn(nbr);
    }

    private void LoopSpawn(int nbrSpawn)
    {
        for(int i = 0; i<nbrSpawn; i++)
        {
            Spawn();
        }
    }

    // spawn randomly objects
    private void Spawn()
    {
        // Take random edge to spawn object
        int randEdge = Random.Range(0, countEdge);
        Vector3 firstEdge = PosEdge(randEdge);
        Vector3 secondEdge = PosEdge(randEdge + 1);

        // take random position on this edge
        float randX = Random.Range(firstEdge.x, secondEdge.x);
        float posY = (secondEdge.y - firstEdge.y) * ((randX - firstEdge.x) / (secondEdge.x - firstEdge.x ));
        posY += firstEdge.y;
        //float randY = Random.Range(PosEdge(randEdge).y, PosEdge(randEdge + 1).y);
        float randZ = Random.Range(minPosZ + shape.gameObject.transform.position.z, maxPosZ + shape.gameObject.transform.position.z);

        // take random object
        GameObject randObj = objects[Random.Range(0, objects.Length)];
        // create the object
        Instantiate(randObj, new Vector3(randX, posY, randZ), Quaternion.identity, this.gameObject.transform);
    }

    // return the position of the point
    private Vector3 PosEdge(int index)
    {
        return shape.spline.GetPosition(index) + shape.gameObject.transform.position;
    }

    

}
