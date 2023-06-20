using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [SerializeField]
    private float minRotation, maxRotation;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(minRotation, maxRotation));
    }
}
