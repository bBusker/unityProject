using UnityEngine;
using System.Collections;
using System;

public class PlayerTail : MonoBehaviour {

    private LinkedList TailList = new LinkedList();
    public GameObject clone;
    private Node current = new Node();
    private Vector3 storedPos;
    private Transform t;


    // Use this for initialization
	public void Start () {
        TailList.start = null;
        TailList.end = null;
	}

    // Update is called once per frame
    public void Update()
    {
        if ((transform.position - transform.position).magnitude > 3F)
        {
            current = TailList.start;
            storedPos = transform.position;
            while (current != null)
            {
                current.tail.transform.position = current.nextPos;
                current.nextPos = storedPos;
                storedPos = current.tail.transform.position;
                current = current.next;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            t = Instantiate(clone, transform.position, Quaternion.identity) as Transform;
            LL_Add(transform.position, t.gameObject, TailList);
        }
    }

    //Linked List
    public class Node
    {
        public Vector3 nextPos;
        public GameObject tail;
        public Node next;
    }
    
    public class LinkedList
    {
        public Node start;
        public Node end;
    }

    public void LL_Add(Vector3 nextPos, GameObject newTail, LinkedList LL)
    {
        Node toAdd = new Node();
        toAdd.nextPos = nextPos;
        toAdd.tail = newTail;
        if(LL.start == null)
        {
            LL.start = toAdd;
            LL.end = toAdd;
            return;
        }
        LL.end.next = toAdd;
        LL.end = toAdd;
    }
}
