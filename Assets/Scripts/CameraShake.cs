using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    float _duration;
    float _magnitude;
    Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    public IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < _duration)
        {
            float x = Random.Range(-1f, 1f) * _magnitude;
            float y = Random.Range(-1f, 1f) * _magnitude;

            transform.position = new Vector3(x, y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.localPosition = _startPosition;
    }

    public void StartShake(float duration, float magnitude)
    {
        _duration = duration;
        _magnitude = magnitude;
        StartCoroutine("Shake");
    }

}
