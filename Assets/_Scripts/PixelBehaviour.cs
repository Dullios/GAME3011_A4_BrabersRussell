using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBehaviour : MonoBehaviour
{
    public float bounds = 960.0f;

    [Header("Sine Movement")]
    public Vector3 pos;
    public float speed;

    public float degrees;
    public float amplitude;
    public float period;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.localPosition;
        pos.x -= speed * Time.deltaTime;

        float degreesPerSecond = 360.0f / period;
        degrees = Mathf.Repeat(degrees + (Time.deltaTime * degreesPerSecond), 360.0f);
        float radians = degrees * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(0.0f, amplitude * Mathf.Sin(radians), 0.0f);
        
        transform.localPosition = (pos + offset);

        if (rectTransform.localPosition.x < -bounds)
            PixelPooling.instance.ReturnToQueue(gameObject);
    }
}
