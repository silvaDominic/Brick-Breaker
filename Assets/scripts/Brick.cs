using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;

    public static int breakableCount = 0;
    public GameObject debris;
    private int timesHit;
    private LevelManager levelManager;
    private GameController gameController;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = this.tag == "Breakable";
        if (isBreakable) {
            breakableCount++;
        }
        gameController = GameObject.FindObjectOfType<GameController>();
        timesHit = 0;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionExit2D(Collision2D collision) {
        if (isBreakable) {
            HandleHits();
        }
    }

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits) {
            breakableCount--;
            GameObject debris = Instantiate(this.debris, this.transform.position, Quaternion.identity) as GameObject;
            debris.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            gameController.BrickDestroyed();
        } else {
            LoadSprites();
        }
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;

        // Checks if sprite exists at given index
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("BRICK SPRITE MISSING AT INDEX " + spriteIndex);
        }
    }


}
