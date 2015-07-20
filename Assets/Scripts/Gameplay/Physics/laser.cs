using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {
	internal float life;
	// Use this for initialization
	void Awake () {
		life = 1.0f;
		Debug.Log("I HERE");
	}
	
	// Update is called once per frame
	void Update () {
		life -= 10f * Time.deltaTime;
		if (life < 0){
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Trash"){
			Destroy(other.gameObject);
        }
	}
}