using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

    public static ScoreUI instance;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }

        else {
            instance = this;
        }
        

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable() {
        GameManager.OnUpdateScore += UpdateScoreUI;
    }

    private void OnDisable() {
        GameManager.OnUpdateScore -= UpdateScoreUI;
    }

    public void UpdateScoreUI() {
        //Cambiar el valor del score en la UI
        Debug.Log("Score actualizado");
    }
}
