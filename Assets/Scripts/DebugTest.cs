using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour {

    void Start() {
        Debug.Log("Hola soy un mensaje");
        Debug.LogWarning("Me estoy acercando al fin");
        Debug.LogError("Hay un error");

        for (int i = 0; i < 10; i++) {
            Debug.LogFormat($"<color=blue> {i} </color>");
        }
    }
}