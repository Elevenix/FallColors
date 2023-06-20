using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBike : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem herbParticule, sandParticule;

    [SerializeField]
    private int minEmit, maxEmit;

    [SerializeField]
    private float accordShake = 1f;

    [SerializeField]
    private SoundPlayer soundPlayer;

    private bool _canShake = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopAllCoroutines();
        if (_canShake && GameManager.GM.IsGameBegin())
        {
            _canShake = false;
            GameManager.GM.CamShaking();
            soundPlayer.StartSounds();
        }

        
        if (collision.gameObject.CompareTag("Herb"))
        {
            var emHerb = herbParticule.emission;
            emHerb.rateOverDistance = Random.Range(minEmit, maxEmit);
        }

        if (collision.gameObject.CompareTag("Sand"))
        {
            var emHerb = sandParticule.emission;
            emHerb.rateOverDistance = Random.Range(minEmit, maxEmit);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(accordShaking());

        
        if (collision.gameObject.CompareTag("Herb"))
        {
            var emHerb = herbParticule.emission;
            emHerb.rateOverDistance = 0;
        }

        if (collision.gameObject.CompareTag("Sand"))
        {
            var emHerb = sandParticule.emission;
            emHerb.rateOverDistance = 0;
        }
    }

    private IEnumerator accordShaking()
    {
        yield return new WaitForSeconds(accordShake);
        _canShake = true;
    }
}
