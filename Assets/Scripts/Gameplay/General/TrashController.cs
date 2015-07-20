using SpacePiercer.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrashController : MonoBehaviour {
	public List<GameObject> trash;
	public static float speed = 20f;
	internal float time = 0.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (MainMenu.InMainMenu) return;
		time += Time.deltaTime;
		if (time > 1){
            for (int i = 0; i < 25; i++)
            {
                var b = Instantiate(trash[Random.Range(0, trash.Count)]);
                b.transform.position = new Vector3(transform.position.x + Random.Range(-70, 70), transform.position.y + Random.Range(-40, 40), transform.position.z + 150);
				b.transform.localScale = new Vector3(2.0f,2.0f,2.0f);
                time = 0.9f;
            }
		}
	}
}
