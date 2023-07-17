using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Vector2 CamPos;
    Vector2 PlayerPos;

    public GameObject Player;
    public GameObject Camera;

    public float distance; // 2.5
    public float step; // 4

    bool centerLock = false;
    void FixedUpdate()
    {
        CamPos = transform.position;
        PlayerPos = Player.transform.position;
        if(centerLock == false && Mathf.Abs((CamPos-PlayerPos).magnitude) > distance )
        {
            centerLock = true;
        }
        if(centerLock == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos, step * Time.deltaTime);
            if(CamPos == PlayerPos)
            {
                centerLock = false;
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
