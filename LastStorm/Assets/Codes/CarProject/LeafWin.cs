using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafWin : MonoBehaviour
{
    [SerializeField]
    private string leafName;

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = this.GetComponent<Animator>();
        if (!PlayerPrefs.HasKey(leafName))
        {
            PlayerPrefs.SetInt(leafName, 0);
        }

        if(PlayerPrefs.GetInt(leafName) != 0)
        { 
            Destroy(this.gameObject);
        }

        //PlayerPrefs.SetInt(leafName, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.GetComponent<Collider2D>().enabled = false;
            GameManager.GM.addLeaf();
            _anim.SetTrigger("win");
            foreach(LeafWin lf in FindObjectsOfType<LeafWin>())
            {
                if (lf.GetLeafName().Equals(this.leafName) && lf.gameObject != this.gameObject)
                {
                    Destroy(lf.gameObject);
                }
            }
            PlayerPrefs.SetInt(leafName, 1);
        }
    }

    public string GetLeafName()
    {
        return this.leafName;
    }
}
