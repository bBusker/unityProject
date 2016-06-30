using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public void play()
    {
        SceneManager.LoadScene("Main");
    }
}
