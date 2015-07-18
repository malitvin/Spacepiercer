using UnityEngine;
using System.Collections;

public class ExplosionMover : MonoBehaviour {

    private float speed = 20f;

	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0, -(Time.deltaTime * speed));
	}
}
