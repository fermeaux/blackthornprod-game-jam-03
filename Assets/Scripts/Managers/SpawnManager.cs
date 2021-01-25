using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnPointHeight = 10f;
    public Vector2 spawnPointMinMax;

    private Wave currentWave;

    public void OnWaveChanged(Wave wave)
    {
        currentWave = wave;
    }

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            var secondsToWait = Random.Range(currentWave.spawnFrequencyMinMax[0], currentWave.spawnFrequencyMinMax[1]);
            yield return new WaitForSeconds(secondsToWait);
            var penguinPrefab = currentWave.GetRandom();
            var radius = penguinPrefab.transform.localScale.x / 2;
            var spawnPointHorizontal = Random.Range(spawnPointMinMax[0] + radius, spawnPointMinMax[1] - radius);
            var position = new Vector3(spawnPointHorizontal, spawnPointHeight, 0);
            var instantiated = Instantiate(penguinPrefab, position, Quaternion.identity);
        }
    }
}
