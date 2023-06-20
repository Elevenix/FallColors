using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{

    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        int randSprite = Random.Range(0, sprites.Length);
        _renderer.sprite = sprites[randSprite];
    }

}
