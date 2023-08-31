using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    [Header("Information")]
    public float fadeTime;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    public void FadeIn() {
        spriteRenderer.DOFade(1, fadeTime).OnComplete(()=> {
            Debug.Log("FadeIn Completo");
        });
    }
    
    [ContextMenu("FadeOut")]
    public void FadeOut() {
        spriteRenderer.DOFade(0, fadeTime).OnComplete(()=> StartGame()).OnStart(() => {
            Debug.Log("FadeOut Iniciado");
        });
    }

    private void StartGame(){
        Debug.Log("FadeOut Completo");
    }

    private void Start() {
        FadeOut();
        GameManager.OnPlayerDeath += FadeIn; //Para suscribir un metodo de otro objeto
    }
}
