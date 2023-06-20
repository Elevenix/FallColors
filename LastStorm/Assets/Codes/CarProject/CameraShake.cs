using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // screen shake (by Brackeys)
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = _mainCamera.transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            _mainCamera.transform.localPosition = new Vector3(x, y, _mainCamera.transform.localPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        _mainCamera.transform.localPosition = originalPos;
    }
}
