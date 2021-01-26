using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public List<TagSO> tags;

    public bool Contains(string tag)
    {
        return tags.Find(tmp => tmp.name == tag) != null;
    }
}
