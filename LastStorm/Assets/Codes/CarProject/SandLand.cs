using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandLand : MonoBehaviour
{
    [SerializeField]
    private LandShape parentLand;

    private LandShape _sand;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 thisPos = this.transform.position;
        this.transform.position = new Vector3(parentLand.GetStartEdge(), thisPos.y, thisPos.z);
    }

}
