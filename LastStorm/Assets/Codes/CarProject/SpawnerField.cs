using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerField : MonoBehaviour
{
    [SerializeField]
    private LandShape mainField;

    [SerializeField]
    private GameObject bridge;

    [SerializeField]
    private float sizeBridg = 5f;

    [SerializeField]
    private float startSpawn ,minSize, maxSize;

    [SerializeField]
    private FieldParameters[] fieldParam;

    private ListSpawner listSpawnerObjects;
    private float _sizeEdge = 0;
    private float startEdge;
    private GameObject[] _fields;
    // Start is called before the first frame update
    void Awake()
    {
        listSpawnerObjects = mainField.gameObject.GetComponent<ListSpawner>();

        startEdge = startSpawn;
    }

    // change the lenght of the array
    public void SetFieldsLenght(int nbr)
    {
        _fields = new GameObject[nbr];
    }

    // create field or/and bridge 
    public void CreateNewField(int index, int indexAtmos)
    {
        print("Atmos : " + indexAtmos);
        // create all objects in background
        listSpawnerObjects.SetSpawner(indexAtmos);
        // set and create the landShape
        FieldParameters fp = fieldParam[indexAtmos];
        mainField.SetParameters(fp.nbrEdgeMin, fp.nbrEdgeMax, fp.randHeight);
        createField(index);
        startEdge += _sizeEdge;

        if (bridge != null)
        {
            createBridge(startEdge, sizeBridg);
            startEdge += sizeBridg;
        }
    }

    public int GetListSpawnerLength()
    {
        return this.listSpawnerObjects.GetLength();
    }

    public GameObject[] ListActualFields()
    {
        return _fields;
    }

    public void DestroyFirstField()
    {
        Destroy(_fields[0].gameObject);
        for(int i = 0; i < _fields.Length-1; i++)
        {
            _fields[i] = _fields[i+1];
        }
    }

    private void createField(int index)
    {
        _sizeEdge = Random.Range(minSize, maxSize);
        mainField.SetStartShape(startEdge, _sizeEdge);
        _fields[index] = Instantiate(mainField.gameObject, this.transform.position, Quaternion.identity);
    }

    private void createBridge(float endField,float sizeBridge)
    {
        Vector3 posSpawn = new Vector3(endField + sizeBridge / 2, this.transform.position.y, this.transform.position.z);
        Instantiate(bridge,posSpawn, Quaternion.identity);
    }
}
