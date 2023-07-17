using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Vector2 CamPos;
    Vector2 PlayerPos;

    public GameObject Player;
    public GameObject Camera;

    public float distanceSet; // 2.5
    public float step; // 4
    float stepDef;
    public float multiplier;

    bool centerLock = false;
    private void Start()
    {
        stepDef = step;
    }
    void FixedUpdate()
    {
        CamPos = transform.position;
        PlayerPos = Player.transform.position;
        float distance = Mathf.Abs((CamPos - PlayerPos).magnitude);

        if (centerLock == false && distance > distanceSet )
        {
            centerLock = true;
        }
        if(centerLock == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos, step * Time.deltaTime);
            if(distance < 0.25)
            {
                transform.position = PlayerPos;
                centerLock = false;
                if(step > stepDef)
                {
                    step -= multiplier;
                } 
            }
        }
        if(distance > distanceSet *2 && step == stepDef)
        {
            step += multiplier;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
