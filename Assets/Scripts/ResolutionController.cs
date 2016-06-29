using UnityEngine;
using System.Collections;

public class ResolutionController : MonoBehaviour {

    public float ResolutionControllerRatio_x;
    public float ResolutionControllerRatio_y;
    private SpriteRenderer sr;

    // Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        ResolutionControllerRatio_x = worldScreenWidth / sr.bounds.size.x;
        ResolutionControllerRatio_y = worldScreenHeight / sr.bounds.size.y;

        transform.localScale = new Vector3(ResolutionControllerRatio_x, ResolutionControllerRatio_y, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
