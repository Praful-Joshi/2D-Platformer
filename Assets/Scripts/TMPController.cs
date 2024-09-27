using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPController : MonoBehaviour
{
    private TextMeshProUGUI KeyText;

    private void Awake() {
        KeyText = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        //code   
    }

    public void KeyReceive() {
        Debug.Log("Key received UI");
    }


}   


