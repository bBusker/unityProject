using UnityEngine;
using System.Collections;

public class ResolutionController : MonoBehaviour {

    private SpriteRenderer sr;

    // Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float x_scale = worldScreenWidth / sr.bounds.size.x;
        float y_scale = worldScreenHeight / sr.bounds.size.y;

        transform.localScale = new Vector3(x_scale, y_scale, 1);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
