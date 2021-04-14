using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum Difficulty
{
    EASY,
    MEDIUM,
    HARD
}

public class GameManager : MonoBehaviour
{
    public Vector2 signalGoal;
    public Color signalColor;

    [Header("Settings")]
    public bool startGame;
    public Difficulty difficulty;

    public int signalsToMatch;
    public int signalsMatched;
    [Space]
    public float timer;
    public TMP_Text timeDisplay;

    [Header("Checkmarks")]
    public GameObject[] checkmarks = new GameObject[5];

    [Header("Panels")]
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

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

        StartDifficulty();
    }

    private void Update()
    {
        if(startGame)
        {
            timer -= Time.deltaTime;
            timeDisplay.text = timer.ToString("00.0");

            if(timer <= 0)
            {
                // TODO: Lose game;
            }
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);

        float x = Random.Range(1.0f, 2.0f);
        x = Mathf.Round(x * 10.0f) / 10.0f;
        float y = Random.Range(10, 101);

        signalGoal = new Vector2(x, y);
        SetPixelColor();

        startGame = true;
    }

    private void StartDifficulty()
    {
        timer = 45.0f;
        signalsToMatch = 3;

        for (int i = 0; i < checkmarks.Length; i++)
        {
            if (i < signalsToMatch)
                checkmarks[i].SetActive(true);
            else
                checkmarks[i].SetActive(false);
        }
    }

    public void SetDifficulty(TMP_Dropdown dropDown)
    {
        difficulty = (Difficulty)dropDown.value;

        switch (difficulty)
        {
            case Difficulty.EASY:
                timer = 45.0f;
                signalsToMatch = 3;

                for (int i = 0; i < checkmarks.Length; i++)
                {
                    if (i < signalsToMatch)
                        checkmarks[i].SetActive(true);
                    else
                        checkmarks[i].SetActive(false);
                }

                break;
            case Difficulty.MEDIUM:
                timer = 60.0f;
                signalsToMatch = 4;

                for (int i = 0; i < checkmarks.Length; i++)
                {
                    if (i < signalsToMatch)
                        checkmarks[i].SetActive(true);
                    else
                        checkmarks[i].SetActive(false);
                }

                break;
            case Difficulty.HARD:
                timer = 75.0f;
                signalsToMatch = 5;

                for (int i = 0; i < checkmarks.Length; i++)
                    checkmarks[i].SetActive(true);

                break;
        }
    }

    public void SetPixelColor()
    {
        Vector2 signal = new Vector2(periodSlider.value, amplitudeSlider.value);
        float dist = Vector2.Distance(signal, signalGoal);
        dist /= 50.0f;

        signalColor = Color.Lerp(Color.green, Color.red, dist);

        OnColorChange.Invoke(signalColor);
    }

    public void ResetGame()
    {
        amplitudeSlider.value = 50;
        periodSlider.value = 1.5f;
    }
}
