using UnityEngine;
using System.Collections;

public class TrashRotor : MonoBehaviour {

	internal float r, g, b;
	// Use this for initialization
	void Start () {
		r = Random.Range(-1,1);
		g = Random.Range(-1,1);
		b = Random.Range(-1,1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(r,g,b);
	}
}
