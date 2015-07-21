using SpacePiercer.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrashController : MonoBehaviour {
	public List<GameObject> trash;
	public static float speed = 20f;
	internal float time = 0.0f;
	internal int span = 50;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (MainMenu.InMainMenu) return;
		time += Time.deltaTime;
		if (time > 1){
            for (int i = 0; i < 20; i++)
            {
                var b = Instantiate(trash[Random.Range(0, trash.Count)]);
                b.transform.position = new Vector3(transform.position.x + Random.Range(-span, span), transform.position.y + Random.Range(-span, span), transform.position.z + 70);
				b.transform.localScale = new Vector3(2.0f,2.0f,2.0f);
                time = 0.9f;
            }
		}
	}
}
