using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform following;

    [SerializeField]
    private float smoothTime;

    [SerializeField]
    private Camera cam;

    private float refVelocity = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, following.position.x, ref refVelocity, smoothTime);
        this.transform.position = new Vector3(posX, this.transform.position.y, this.transform.position.z);
    }

    public void SetFollowing(Transform player)
    {
        this.following = player;
    }

    public void SetSize(float newFieldOfView)
    {
        cam.fieldOfView = newFieldOfView;
    }

    public float GetSize()
    {
        return cam.fieldOfView;
    }
}
