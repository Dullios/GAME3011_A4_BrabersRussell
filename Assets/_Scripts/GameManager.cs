using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector2 signalGoal;

    [Header("Sliders")]
    public Slider amplitudeSlider;
    public Slider periodSlider;

    public UnityEvent<Color> OnColorChange;
    
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void StartGame()
    {
        float x = Random.Range(1.0f, 2.0f);
        x = Mathf.Round(x * 10.0f) / 10.0f;
        float y = Random.Range(10, 101);

        signalGoal = new Vector2(x, y);
        SetPixelColor();
    }

    public void SetPixelColor()
    {
        Vector2 signal = new Vector2(periodSlider.value, amplitudeSlider.value);
        float dist = Vector2.Distance(signal, signalGoal);
        dist = Mathf.Clamp(dist, 0, 1);

        Color warm = Color.Lerp(Color.green, Color.red, dist);

        OnColorChange.Invoke(warm);
    }

    public void ResetGame()
    {
        amplitudeSlider.value = 50;
        periodSlider.value = 1.5f;
    }
}
