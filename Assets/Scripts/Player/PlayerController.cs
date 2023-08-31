using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [Header("Information")]
    public Rigidbody2D rb;

    public float movementX;
    public float movementY;

    public float speed;
    public int rotSpeed;
    public float maxSpeed;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    /* Desactivando los controles al jugador al morir 
    (otra manera de suscribirnos a un evento tambien) */
    private void Awake() {
        GameManager.OnPlayerDeath += ()=>{
            TryGetComponent(out PlayerInput playerInput);
            playerInput.actions.FindActionMap("Player").Disable();
        };
    }
    /* ----------------------------------------------- */

    private void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnFire() {
        SoundManager.instance.PlayShoot();
        GameObject go = ObjectPooler.instance.GetPoolObject("Bullet");
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        go.SetActive(true);
    }

    private void FixedUpdate() {
        rb.rotation -= movementX * rotSpeed;
        speed = Mathf.Clamp(speed + movementY, 1.5f, maxSpeed);
        rb.velocity = transform.up * speed;
    }
}
