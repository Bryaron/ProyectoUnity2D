using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour {

    [Header("Configuration")]
    public Transform target;
    public Rigidbody2D rb;

    [Header("Information")]
    public float speed;
    public float angle;
    public float cO;
    public float cA;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {

        rb.velocity = (target.position - transform.position).normalized * speed;    
            
        cO = transform.position.x - target.position.x;
        cA = target.position.y - transform.position.y;
        angle = Mathf.Atan2(cO, cA)* Mathf.Rad2Deg;
        rb.rotation = angle;

    }
}
