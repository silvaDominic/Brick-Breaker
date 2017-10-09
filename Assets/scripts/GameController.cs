using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private LevelManager levelManager;
    public int ballLives = 1;
    private Ball ball;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    public void BallDeath() {
        print("Enter Ball Death");
        ballLives--;
        if (ballLives <= 0) {
            print("No lives left");
            Lose();
        } else {
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f);
            ball.ResetBall();
            print(ballLives + " remaining");
        }
    }

    void Win() {
        levelManager.LoadLevel("win");
    }

    void Lose() {
        levelManager.LoadLevel("lose");
    }

    public void BrickDestroyed() {
        if (Brick.breakableCount <= 0) {
            levelManager.LoadNextLevel();
        }
    }

    // Update is called once per frame
    void Update () {
    }
}
