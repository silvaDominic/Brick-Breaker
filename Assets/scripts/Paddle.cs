using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;
    public float LEFTEDGE;
    public float RIGHTEDGE;

    private void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    void MoveWithMouse() {
        // Calculates the current mouse position in game world units and restricts value between game window
        float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, LEFTEDGE, RIGHTEDGE);
        // The paddle position as a 3D Vector
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        // Updates the current x value of the paddle to the current mouse position
        paddlePos.x = mousePosInBlocks;

        // Sets the instance of paddle to the current paddle position
        this.transform.position = paddlePos;
    }

    void AutoPlay() {
        const float LEFTEDGE = 0.5f;
        const float RIGHTEDGE = 15.5f;

        // Calculates the current mouse position in game world units and restricts value between game window
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, LEFTEDGE, RIGHTEDGE);
        this.transform.position = paddlePos;
    }
}
