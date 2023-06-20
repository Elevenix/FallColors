using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SpawnerField[] spawnersFields;

    [SerializeField]
    private int maxField, startRandom;

    [SerializeField]
    private SpawnerField mainField;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject squirrel;

    [SerializeField]
    private GameObject[] leafWinPos;

    [SerializeField]
    private GameObject gate;

    [Header("Camera shake")]

    [SerializeField]
    private CameraShake camShake;

    [SerializeField]
    private float duration, magnitude;

    public static GameManager GM;

    private int _nbrLeaf;
    private MenuGame _menuGame;
    private bool _gameBeginning = false;
    // Start is called before the first frame update
    void Start()
    {
        _nbrLeaf = 0;
        if(GM != null)
        {
            Destroy(this);
        }
        else
        {
            GM = this;
        }
        _menuGame = GetComponent<MenuGame>();

        if (!PlayerPrefs.HasKey("Win"))
        {
            PlayerPrefs.SetInt("Win", 0);
        }

        foreach (SpawnerField sp in spawnersFields)
        {
            sp.SetFieldsLenght(maxField);
        }

        startSpawn();

        activateLeaf();

        //PlayerPrefs.SetInt("Win", 0);
    }

    private void startSpawn()
    {
        for (int i = 0; i < maxField; i++)
        {
            int atmos = 0;
            if (i >= startRandom)
            {
                atmos = Random.Range(0, mainField.GetListSpawnerLength());
            }

            foreach (SpawnerField sf in spawnersFields)
            {
                // start with forest 
                sf.CreateNewField(i, atmos);
            }
        }
    }

    private void activateLeaf()
    {
        for(int i=0; i<PlayerPrefs.GetInt("Win"); i++)
        {
            leafWinPos[i].SetActive(true);
        }

        if(PlayerPrefs.GetInt("Win") == leafWinPos.Length)
        {
            gate.GetComponent<Collider2D>().enabled = false;
            Vector3 gatePos = gate.transform.position;
            gate.transform.position = new Vector3(gatePos.x, gatePos.y, gatePos.z + 3);
        }
    }

    public void addLeaf()
    {
        leafWinPos[_nbrLeaf].SetActive(true);
        _nbrLeaf++;
        PlayerPrefs.SetInt("Win", PlayerPrefs.GetInt("Win") + 1);
        activateLeaf();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(mainField.ListActualFields()[maxField-1].transform.position.x < player.transform.position.x)
        {
            // create the squirrel that block the way
            Vector3 posSquirrel = mainField.ListActualFields()[2].transform.position;
            posSquirrel.x -= 10f;
            Instantiate(squirrel, posSquirrel, Quaternion.identity);

            // random atmosphere (Spawner objects)
            int atmos = Random.Range(0, mainField.GetListSpawnerLength());
            // create the new fields
            foreach (SpawnerField sp in spawnersFields)
            {
                sp.DestroyFirstField();
                sp.CreateNewField(maxField-1, atmos);
            }
        }
    }

    public void BeginGame()
    {
        _menuGame.StartGame();
        _gameBeginning = true;
    }

    public void CamShaking()
    {
        StartCoroutine(camShake.Shake(duration, magnitude));
    }

    public bool IsGameBegin()
    {
        return this._gameBeginning;
    }
}
