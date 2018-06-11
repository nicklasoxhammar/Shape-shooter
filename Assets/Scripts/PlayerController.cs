using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float playerSpeed = 2f;

    Rigidbody2D rb;


    void Start() {

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {

        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = targetVelocity.normalized * playerSpeed;
        
    }
  }


  