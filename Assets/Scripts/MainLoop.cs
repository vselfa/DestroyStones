using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MainLoop : MonoBehaviour {
    public GameObject[] stones = new GameObject[3]; // An array of GameObjects
    public float torque = 1.0f; // Spacial force to provoque a rotation
    // Different min and max values to give random to the stones
    public float minAntiGravity = 1.0f, maxAntiGravity = 2.0f;
    public float minLateralForce = -1.0f, maxLateralForce = 1.0f;
    public float minTimeBetweenStones = 3f, maxTimeBetweenStones = 5f;
    public float minX = -1.0f, maxX = 1.0f;
    public float minZ = -4.0f, maxZ = -2.0f;
    private bool enableStones = true;
    private Rigidbody rigidBody;

    private float x0, y0, z0;

    // Use this for initialization
    void Start()     {       
         StartCoroutine(ThrowStones());     
    }
    
    // To run the coroutine
   IEnumerator ThrowStones() {
    // Initial delay
    yield return new WaitForSeconds(2.0f);
    while (enableStones) {
        // Random values for: the kind of stone, position and rotation of the initial values
        GameObject stone = (GameObject) Instantiate(stones[Random.Range(0, stones.Length)]);

        x0 = Random.Range(minX, maxX);
        y0 = 0.5f;
        z0 = Random.Range(minZ, maxZ);

        stone.transform.position = new Vector3(x0, y0, z0 );
        stone.transform.rotation = Random.rotation;

        // print ("x,y,z =" + x0 + " " + y0 + " " + z0);

 	    rigidBody = stone.GetComponent<Rigidbody>();
        // Rotation
        rigidBody.AddTorque(Vector3.up * torque, ForceMode.Impulse);
        rigidBody.AddTorque(Vector3.right * torque, ForceMode.Impulse);
        rigidBody.AddTorque(Vector3.forward * torque, ForceMode.Impulse);
        // Force 
        rigidBody.AddForce(Vector3.up * Random.Range(minAntiGravity, maxAntiGravity), 
                                        ForceMode.Impulse);
        rigidBody.AddForce(Vector3.right * Random.Range(minLateralForce, maxLateralForce), 
                                            ForceMode.Impulse);
	    // Next time to run the coroutine
        yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
    }
}
}


