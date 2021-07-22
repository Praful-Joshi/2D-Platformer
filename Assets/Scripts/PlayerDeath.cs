using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void Update() {
        if(transform.position.y <= -12f)
        {
            Destroy(gameObject);
            LevelFinish.instance.Respawn();
        }
    }
}
