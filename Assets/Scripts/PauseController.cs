using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
    public Transform canvas; 

	void Start () {
	}
	
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
                    
        }
	}
}
