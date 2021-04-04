using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBehaviour : MonoBehaviour
{
    public float bounds = 960.0f;
    public float speed;

    public Vector3 pos;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;

        if (rectTransform.localPosition.x < -bounds)
            PixelPooling.instance.ReturnToQueue(gameObject);
    }
}
