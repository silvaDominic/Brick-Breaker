using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

    private GameController gameController;

    private void Start() {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        gameController.BallDeath();
    }
}
