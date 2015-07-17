using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*Custom Class to add to objects that you want to fade in and out*/
[RequireComponent(typeof(CanvasGroup))]
public class FadeChange : MonoBehaviour {

    private CanvasGroup grid;

    [Header("Fade Speed")]
    public float speed;

	/*Called on Application Start*/
	private void Start () {
        grid = GetComponent<CanvasGroup>();
	}

    public void FadeTo(float alpha)
    {
        iTween.ValueTo(this.gameObject, iTween.Hash(
          "from", grid.alpha,
          "to", alpha,
          "time", speed,
          "onupdate", "Alpha"));
    }

    private void Alpha(float newValue)
    {
        grid.alpha = newValue;
    }

    private void OnDestroy()
    {
        grid = null;
    }
}
