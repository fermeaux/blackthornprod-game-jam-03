using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public int waveFrequency;
    [SerializeField]
    private WaveSO waves;
    public UnityEvent<Wave> waveChanged;

    private int waveId = -1;

    public void ChangeWave()
    {
        waveId = Mathf.Min(waveId + 1, waves.waves.Count - 1);
        waveChanged?.Invoke(waves.waves[waveId]);
    }

    private void Start()
    {
        StartCoroutine(WaveLoop());
    }

    private IEnumerator WaveLoop()
    {
        while (true)
        {
            ChangeWave();
            yield return new WaitForSeconds(waveFrequency);
        }
    }
}
