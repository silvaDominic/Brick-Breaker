using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    private void Awake() {
        Debug.Log("Music Player Awake " + GetInstanceID());
        if (instance != null) {
            Destroy(gameObject);
            print("Duplicate Music Player destroyed.");
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
