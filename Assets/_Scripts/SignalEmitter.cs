using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalEmitter : MonoBehaviour
{
    [Header("Spawn Settings")]
    public float spawnRate;
    [SerializeField]
    private float timer;

    [Header("Sine Movement")]
    private Vector3 pos;
    [SerializeField]
    private float degrees;
    [Range(10, 100)]
    public float amplitude;
    [Range(1, 2)]
    public float period;

    // Update is called once per frame
    void Update()
    {
        // Emit Pixels
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            GameObject pixel = PixelPooling.instance.RetrieveFromQueue();
            pixel.transform.position = transform.position;
            timer = 0;
        }

        // Sine Movement
        pos = transform.localPosition;

        float degreesPerSecond = 360.0f / period;
        degrees = Mathf.Repeat(degrees + (Time.deltaTime * degreesPerSecond), 360.0f);
        float radians = degrees * Mathf.Deg2Rad;

        pos.y = amplitude * Mathf.Sin(radians);

        transform.localPosition = pos;
    }
}
