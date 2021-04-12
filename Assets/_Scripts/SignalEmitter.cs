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
    public Vector3 pos;

    [SerializeField]
    private float degrees;
    [Range(0, 50)]
    public float amplitude;
    [Range(0, 10)]
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

        Vector3 offset = new Vector3(0.0f, amplitude * Mathf.Sin(radians), 0.0f);

        transform.localPosition = (pos + offset);
    }
}
