using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloeLimit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var penguin = col.GetComponent<PenguinMovement>();
        var player = col.GetComponent<PlayerMovement>();
        if (penguin != null || player != null)
        {
            Destroy(col.gameObject);
        }
    }
}
