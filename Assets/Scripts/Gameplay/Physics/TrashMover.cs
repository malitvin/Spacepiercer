using UnityEngine;
using System.Collections;

public class TrashMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0,0, -1 * TrashController.speed * Time.deltaTime );
		if (transform.position.z < -30)
			Destroy(gameObject);
	}
}
