using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int combo = 1;
    public int comboFrequency = 5;
    public int penguinKilledScore = 5;
    public UnityEvent<int> scoreChanged;
    public UnityEvent<int> comboChanged;

    private float lastCollision;

    public void OnPlayerCollide()
    {
        lastCollision = Time.time;
        ChangeCombo(1);
    }

    public void OnPenguinKilled()
    {
        ChangeScore(penguinKilledScore);
    }

    public void ChangeScore(int modifier)
    {
        score += modifier;
        scoreChanged?.Invoke(score);
    }

    public void ChangeCombo(int newValue)
    {
        combo = newValue;
        comboChanged?.Invoke(combo);
    }

    private void Awake()
    {
        lastCollision = Time.time;
    }

    private void Start()
    {
        StartCoroutine(ScoreLoop());
    }

    private void Update()
    {
        var currentCombo = Mathf.CeilToInt((Time.time - lastCollision) / comboFrequency);
        if (currentCombo > combo)
        {
            ChangeCombo(currentCombo);
        }
    }

    private IEnumerator ScoreLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ChangeScore(combo);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("lastScore", score);
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
