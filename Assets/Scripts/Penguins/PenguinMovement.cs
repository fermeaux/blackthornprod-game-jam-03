using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovement : MonoBehaviour
{
    public Vector2 velocityMinMax;

    private float velocity;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = Random.Range(velocityMinMax[0], velocityMinMax[1]);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * velocity;
    }
}
