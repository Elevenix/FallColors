using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRide : MonoBehaviour
{
    [SerializeField]
    private CameraMovement cam;

    [SerializeField]
    private float setFieldView;

    [SerializeField]
    private float smoothTime = 0.2f;

    private bool _changeView = false;
    private float refVelocity = .0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (_changeView)
        {
            float fv = Mathf.SmoothDamp(cam.GetSize(), setFieldView, ref refVelocity, smoothTime);
            cam.SetSize(fv);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 0f;
            cam.SetFollowing(this.gameObject.transform);
            _changeView = true;
        }
    }
}
