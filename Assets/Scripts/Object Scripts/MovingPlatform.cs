using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float dirX, moveSpeed = 2f;
    bool moveUP = true;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 5.86f)
        {
            moveUP = false;
        }
        if(transform.position.y < -0.53)
        {
            moveUP = true;
        }

        if(moveUP)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
