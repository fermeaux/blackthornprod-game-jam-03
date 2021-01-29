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
    public Slider musicSlider;

    private void Start()
    {
        highScoreTM.SetText(PlayerPrefs.GetInt("highScore", 0));
        lastScoreTM.SetText(PlayerPrefs.GetInt("lastScore", 0));
        string inputType = PlayerPrefs.GetString("inputType", "Point");
        inputTypeDropdown.SetValueWithoutNotify(inputTypeDropdown.options.FindIndex(option => option.text == inputType));
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        MusicManager.instance?.PlayIntro();
    }

    public void OnMusicVolumeChanged(float volume)
    {
        PlayerPrefs.SetFloat("musicVolume", volume);
        MusicManager.instance?.ChangeVolume();
    }

    public void StartGame()
    {
        MusicManager.instance?.PlayMusic();
        SceneManager.LoadScene("Game");
    }

    public void OnInputModeChanged(int value)
    {
        PlayerPrefs.SetString("inputType", inputTypeDropdown.options[value].text);
    }
}
