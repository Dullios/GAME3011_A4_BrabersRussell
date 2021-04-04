using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPooling : MonoBehaviour
{
    public GameObject pixelPrefab;
    public int poolSize;
    private Queue<GameObject> poolQueue = new Queue<GameObject>();

    public static PixelPooling instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject pixel = Instantiate(pixelPrefab, transform);
            poolQueue.Enqueue(pixel);

            pixel.transform.position = Vector3.zero;
            pixel.SetActive(false);
        }
    }

    public GameObject RetrieveFromQueue()
    {
        GameObject pixel = poolQueue.Dequeue();
        pixel.SetActive(true);

        return pixel;
    }

    public void ReturnToQueue(GameObject pixel)
    {
        pixel.SetActive(false);
        pixel.transform.position = Vector3.zero;
        poolQueue.Enqueue(pixel);
    }
}
