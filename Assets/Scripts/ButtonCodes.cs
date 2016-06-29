using UnityEngine;
using System.Collections;

public class ButtonCodes : MonoBehaviour {
    public GameObject pauseButton, pausePanel;
    public Transform menu; 

    public void unPause()
    {
        Time.timeScale = 1;
        menu.gameObject.SetActive(false);
    }
}
