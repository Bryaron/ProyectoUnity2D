using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /*------------- Delegates---------------- */
    
    /* delegate void SimpleMesage();
    SimpleMesage simpleMesage;

    private void Start() {
        simpleMesage += SendConsoleMessage;
        simpleMesage?.Invoke();
    }

    private void SendConsoleMessage() {
        Debug.Log("Mensaje enviado a consola");
    } */

    /*--------------- Events ----------------*/

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public GameObject GameOverScreen;
    public static Action OnUpdateScore;


    private void Awake() {
        GameOverScreen.SetActive(false);
        OnPlayerDeath += ShowGameOverScreen;
    }

    private void ShowGameOverScreen() {
        GameOverScreen.SetActive(true);
    }

    public void PlayerKilled() {
        OnPlayerDeath?.Invoke();
    }
}
