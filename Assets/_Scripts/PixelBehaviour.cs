using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelBehaviour : MonoBehaviour
{
    private Vector3 pos;

    public float speed;
    public float bounds = 960.0f;

    private RectTransform rectTransform;
    private Image image;
    
    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        GameManager.instance.OnColorChange.AddListener(ChangeColor);
        image.color = GameManager.instance.signalColor;
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

    public void ChangeColor(Color c)
    {
        image.color = c;
    }

    private void OnDisable()
    {
        GameManager.instance.OnColorChange.RemoveListener(ChangeColor);
    }
}
