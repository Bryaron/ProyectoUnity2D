using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipMovement : MonoBehaviour {
    
    public Ease ease;
    private void Start() {

        if (transform.position.x < Vector2.zero.x) {
            transform.DOMoveX(-2.5f,4).SetEase(ease);
        }

        else {
            transform.DOMoveX(2.5f,4).SetEase(ease);
        }
    }

}
