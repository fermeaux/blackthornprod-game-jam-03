using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip intro;
    public List<AudioClip> musics;
    public static MusicManager instance;

    private int index = 0;
    private AudioSource audioSource;
    private bool isInGame;
    private Coroutine musicCoroutine;

    public void PlayIntro()
    {
        if (musicCoroutine != null)
        {
            StopCoroutine(musicCoroutine);
        }
        musicCoroutine = StartCoroutine(IntroLoop());
    }

    public void PlayMusic()
    {
        if (musicCoroutine != null)
        {
            StopCoroutine(musicCoroutine);
        }
        musicCoroutine = StartCoroutine(MusicLoop());
    }

    public void ChangeVolume()
    {
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        instance = this;
        audioSource = GetComponent<AudioSource>();
        ChangeVolume();
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator IntroLoop()
    {
        yield return new WaitUntil(() => audioSource != null);
        while (true)
        {
            audioSource.clip = intro;
            audioSource.Play();
            yield return new WaitForSeconds(intro.length);
        }
    }

    private IEnumerator MusicLoop()
    {
        while (true)
        {
            var music = musics[index % musics.Count];
            audioSource.clip = music;
            audioSource.Play();
            yield return new WaitForSeconds(music.length);
            index++;
        }
    }
}
