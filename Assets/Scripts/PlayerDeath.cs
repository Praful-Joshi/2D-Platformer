using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void Update() {
        if(transform.position.y <= -12f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
