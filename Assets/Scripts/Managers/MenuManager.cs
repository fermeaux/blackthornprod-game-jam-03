using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextManager highScoreTM;
    public TextManager lastScoreTM;

    private void Start()
    {
        highScoreTM.SetText(PlayerPrefs.GetInt("highScore"));
        lastScoreTM.SetText(PlayerPrefs.GetInt("lastScore"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
