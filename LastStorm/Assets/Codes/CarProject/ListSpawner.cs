using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawners;

    public void SetSpawner(int index)
    {
        
        foreach(GameObject o in spawners)
        {
            o.SetActive(false);
        }

        if(index < spawners.Length)
        {
            spawners[index].SetActive(true);
        }
    }

    public int GetLength()
    {
        return spawners.Length;
    }
}
