using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    public void ResetBall() {
        this.transform.position = paddle.transform.position + paddleToBallVector;
    }

    public void LaunchBall() {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 16f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("collision with " + collision.gameObject);
        // Optional offset bounce
        // Vector2 offSetBounce = new Vector2(Random.Range(0, 0.2f), 0f);
        // this.GetComponent<Rigidbody2D>().velocity += offSetBounce;
    }

    // Update is called once per frame
    void Update () {
        if (!hasStarted) {
            // Lock ball relative to paddle
            ResetBall();

            // Wait for mouse press to launch ball
            if (Input.GetMouseButtonDown(0)) {
                hasStarted = true;
                LaunchBall();
            }
        }
	}
}
