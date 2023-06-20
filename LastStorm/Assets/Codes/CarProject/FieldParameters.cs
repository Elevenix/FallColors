using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="FieldParam")]
public class FieldParameters : ScriptableObject
{
    public int nbrEdgeMin, nbrEdgeMax;
    public Vector2 randHeight;
}
