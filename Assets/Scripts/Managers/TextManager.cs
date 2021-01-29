using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public string prefix;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void SetText(int value)
    {
        text.text = $"{prefix}{value}";
    }
}
