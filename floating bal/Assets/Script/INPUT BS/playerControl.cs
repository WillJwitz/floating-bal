using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float speed = 1;
    public Rigidbody2D rBody;

    public void Move(Vector2 input)
    {
        rBody.velocity = input * speed;
    }
}
