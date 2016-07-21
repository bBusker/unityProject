using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using static PlayerTail;

public class PlayerPickup : MonoBehaviour {

    public int scoreCount;
    public Text score;
    public GameObject foodPickup;
    public GameObject foodPickup_tiny;
    public GameObject magnetPickup;
    public bool MagnetPowerup_enabled;

    private float PickupRange_x;
    private float PickupRange_y;
    private GameObject Background;
    private ResolutionController ResolutionController;
    private GameObject Player;
    private PlayerTail playerTail;

    void Start () {
        scoreCount = 0;
        SetCountText();
        Player = GameObject.Find("Player");
        playerTail = Player.GetComponent<PlayerTail>();
        Background = GameObject.Find("Background");
        ResolutionController = Background.GetComponent<ResolutionController>();
        PickupRange_x = 20F * ResolutionController.ResolutionControllerRatio_x;
        PickupRange_y = 10F * ResolutionController.ResolutionControllerRatio_y;
        MagnetPowerup_enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Pickup":
                SpawnPickup(foodPickup);
                scoreCount += 5;
                SetCountText();
                break;
            case "TinyPickup":
                SpawnPickup(foodPickup_tiny);
                scoreCount += 1;
                SetCountText();
                break;
            case "Magnet":
                StartCoroutine(MagnetPickup());
                break;
        }
        other.gameObject.SetActive(false);
        Destroy(other.gameObject);
    }

    IEnumerator MagnetPickup()
    {
        MagnetPowerup_enabled = true;
        yield return new WaitForSeconds(10F);
        MagnetPowerup_enabled = false;
        yield return new WaitForSeconds(5F);
        SpawnPickup(magnetPickup);
    }

    void SpawnPickup(GameObject pkup)
    {
        Vector2 location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
        while (checkPkupLocation(playerTail.TailList, location) == true)
        {
            location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
        }
        Instantiate(pkup, location, Quaternion.identity);
    }

    bool checkPkupLocation(LinkedList LL, Vector3 position)
    {
        if (Vector3.Magnitude(transform.position - position) <= 6)
        {
            return true;
        }
        bool flag = false;
        Node current = LL.start;
        while (current != LL.end)
        {
            if (Vector3.Magnitude(current.tail.transform.position - position) <= 4F)
            {
                return true;
            }
            current = current.next;
        }
        return flag;
    }

    void SetCountText()
    {
        score.text = "SCORE: " + scoreCount.ToString();
    }
}
