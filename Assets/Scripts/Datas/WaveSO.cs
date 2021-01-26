using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Probability<T>
{
    [Range(0, 100)]
    public float probability;
    public T item;
}

[System.Serializable]
public class Wave
{
    public Vector2 spawnFrequencyMinMax;
    public List<Probability<GameObject>> probabilities;

    public GameObject GetRandom()
    {
        float r = Random.Range(0, 100);
        float cumul = 0;
        for (int i = 0; i < probabilities.Count; i++)
        {
            cumul += probabilities[i].probability;
            if (r < cumul)
            {
                return probabilities[i].item;
            }
        }
        return null;
    }
}

[CreateAssetMenu(menuName = "Datas/Waves")]
public class WaveSO : ScriptableObject
{
    public List<Wave> waves;
}
