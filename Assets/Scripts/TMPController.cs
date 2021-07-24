using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPController : MonoBehaviour
{
    // public TextMeshProUGUI KeyText;
    public GameObject keyTMP;

    public IEnumerator KeyReceive() {
        keyTMP.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        keyTMP.SetActive(false);
    }


}   


