using UnityEngine;
using System.Collections;
using System;

public class PlayerTail : MonoBehaviour {

    private LinkedList TailList = new LinkedList();
    public GameObject clone;
    private Node currentNode;
    private Vector3 storedPos;


    // Use this for initialization
	public void Start () {
        TailList.start = null;
        TailList.end = null;
	}

    // Update is called once per frame
    public void Update()
    {
        if ((TailList.start.tail.transform.position - transform.position).magnitude > 1.5F)
        {
            currentNode = TailList.start;
            storedPos = transform.position;
            currentNode.nextPos = storedPos;
            while (currentNode != null)
            {
                currentNode.tail.transform.position = currentNode.nextPos;
                currentNode.nextPos = storedPos;
                storedPos = currentNode.tail.transform.position;
                currentNode = currentNode.next;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            LL_Add(TailList, Instantiate(clone, transform.position, Quaternion.identity) as GameObject, transform.position);
        }
    }

    //Linked List
    public class Node
    {
        public Vector3 nextPos;
        public GameObject tail;
        public Node next;
        public Vector3 rotation;
    }
    
    public class LinkedList
    {
        public Node start;
        public Node end;
    }

    public void LL_Add(LinkedList LL, GameObject newTail, Vector3 nextPos)
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
