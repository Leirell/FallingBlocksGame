using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement :MonoBehaviour {

    public float speed = 7;
    public float screenHalfWidthInWorldUnits;
    public float halfPlayerWidth;
    public event System.Action OnPlayerDeath;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start () {
        halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update () {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        velocity = input.normalized * speed;

        if (transform.position.x < -screenHalfWidthInWorldUnits + -halfPlayerWidth) {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits + halfPlayerWidth) {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void FixedUpdate () {
        transform.position += velocity * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter (Collider triggerCollider) {
        if (triggerCollider.tag == "Obstacle") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }
            Destroy(transform.gameObject);
        }
    }
}
