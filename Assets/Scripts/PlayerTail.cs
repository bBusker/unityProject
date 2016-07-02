using UnityEngine;
using System.Collections;
using System;

public class PlayerTail : MonoBehaviour {


    public LinkedList TailList = new LinkedList();
    public GameObject Tail;
    public float updateDist;
    public int tailGrowth;
    private int tailAddCount;
    private Node currentNode;
    private Vector3 storedPos;
    private Quaternion storedRot;


    // Use this for initialization
	public void Start ()
    {
        TailList.start = null;
        TailList.twenty = null;
        TailList.end = null;
        TailList.size = 0;
        tailAddCount = 0;
	}

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (tailAddCount > 0)
        {
            addTail();
            tailAddCount--;
        }
        Debug.Log(TailList.size);
        TailList.end.tail.tag = "Tail";
        TailList.end.tail.transform.position = transform.position;
        TailList.end.tail.transform.rotation = transform.rotation;
        TailList.end.next = TailList.start;
        TailList.start.previous = TailList.end;
        TailList.end = TailList.end.previous;
        TailList.start = TailList.start.previous;
        TailList.twenty.tail.tag = "Collision";
        TailList.twenty = TailList.twenty.previous;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            tailAddCount += tailGrowth;
        }
    }

    void addTail()
    {
        Quaternion rotation;
        Vector3 position;
        if (TailList.start == null)
        {
            rotation = transform.rotation;
            position = transform.position - transform.right * updateDist;
            LL_Add(TailList, Instantiate(Tail, position, rotation) as GameObject);
        }
        else if (TailList.size == 19)
        {
            rotation = TailList.end.tail.transform.rotation;
            position = TailList.end.tail.transform.position - TailList.end.tail.transform.right * updateDist;
            LL_Add(TailList, Instantiate(Tail, position, rotation) as GameObject);
            TailList.twenty = TailList.end;
        }
        else
        {
            rotation = TailList.end.tail.transform.rotation;
            position = TailList.end.tail.transform.position - TailList.end.tail.transform.right * updateDist;
            LL_Add(TailList, Instantiate(Tail, position, rotation) as GameObject);
        }
    }

    //Linked List
    public class Node
    {
        public GameObject tail;
        public Node next;
        public Node previous;
    }
    
    public class LinkedList
    {
        public Node start;
        public Node twenty;
        public Node end;
        public int size;
    }

    public void LL_Add(LinkedList LL, GameObject newTail)
    {
        Node toAdd = new Node();
        toAdd.tail = newTail;
        toAdd.next = null;
        toAdd.previous = LL.end;

        if(LL.size > 20)
        {
            toAdd.tail.tag = "Collision";
        }

        if(LL.start == null)
        {
            LL.start = toAdd;
            LL.end = toAdd;
            return;
        }

        LL.end.next = toAdd;
        LL.end = toAdd;
        LL.size++;
    }

    public bool checkPkupLocation(LinkedList LL, Vector3 position)
    {
        if(Vector3.Magnitude(transform.position - position) <= 6)
        {
            return true;
        }
        bool flag = false;
        Node current = LL.start;
        while(current != null)
        {
            if(Vector3.Magnitude(current.tail.transform.position - position) <= 4F)
            {
                return true;
            }
            current = current.next;
        }
        return flag;
    }
}
