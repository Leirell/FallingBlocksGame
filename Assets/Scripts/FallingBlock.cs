using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock :MonoBehaviour {
    float speed = 7;
    float visibleHeightThreshold;

    // Start is called before the first frame update
    void Start () {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < visibleHeightThreshold) {
            Destroy(gameObject);
        }
    }
}
