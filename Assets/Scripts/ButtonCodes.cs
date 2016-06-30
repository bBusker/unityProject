using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonCodes : MonoBehaviour
{
    public Transform UIOverlay;

    public void unPause()
    {
        Time.timeScale = 1;
        UIOverlay.gameObject.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}
