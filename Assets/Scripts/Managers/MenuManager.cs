using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextManager highScoreTM;
    public TextManager lastScoreTM;
    public Dropdown inputTypeDropdown;

    private void Start()
    {
        highScoreTM.SetText(PlayerPrefs.GetInt("highScore", 0));
        lastScoreTM.SetText(PlayerPrefs.GetInt("lastScore", 0));
        string inputType = PlayerPrefs.GetString("inputType", "Point");
        inputTypeDropdown.SetValueWithoutNotify(inputTypeDropdown.options.FindIndex(option => option.text == inputType));
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnInputModeChanged(int value)
    {
        PlayerPrefs.SetString("inputType", inputTypeDropdown.options[value].text);
    }
}
