using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBehaviour : MonoBehaviour
{
    public float bounds = 960.0f;

    public Vector3 pos;
    public float speed;

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

        transform.localPosition = (pos);

        if (rectTransform.localPosition.x < -bounds)
            PixelPooling.instance.ReturnToQueue(gameObject);
    }
}
