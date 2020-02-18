using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone: MonoBehaviour {
    // Distance to the stone be destroyed
    private const float yDie = -30.0f;

    private  AudioSource explosionAudioSource;

    public GameObject explosion;

    // Use this for initialization
    void Start () {         
        print ("Stone created!!");
        explosionAudioSource = GetComponent<AudioSource>();     
	}
    // Update is called once per frame
    void Update () {
        // Position stone < yDie
		if (transform.position.y < yDie)  {  
			// Destroy the game to witch this script is associated
			Destroy(gameObject);  
        }
   }

    // Detect if the object intercep the ray
    void OnMouseDown() { 
        // Create an explosion effect here, with no rotation
        explosionAudioSource.Play();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.currentNumberStonesDestroyed++;
    }
}
