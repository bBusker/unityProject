using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
    public Transform UIOverlay;
    
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController controller = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller.gameover == false) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (UIOverlay.gameObject.activeInHierarchy == false)
                {
                    UIOverlay.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    UIOverlay.gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
    }
}
