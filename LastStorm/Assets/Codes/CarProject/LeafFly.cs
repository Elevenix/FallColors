using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFly : MonoBehaviour
{

    [SerializeField]
    private GameObject leaf;

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _anim.SetTrigger("leaf");
            Instantiate(leaf, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject, 2f);
        }
    }
}
