﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerTail : MonoBehaviour {


    public LinkedList TailList = new LinkedList();
    public GameObject Tail_WithTrigger;
    public GameObject Tail_WithoutTrigger;
    public float updateDist;
    public int tailGrowth = 3;
    private int tailAddCount;
    private Node currentNode;
    private Vector3 storedPos;
    private Quaternion storedRot;


    // Use this for initialization
	public void Start ()
    {
        TailList.start = null;
        TailList.end = null;
        TailList.size = 0;
	}

    // Update is called once per frame
    public void FixedUpdate()
    {
        currentNode = TailList.start;
        storedPos = transform.position;
        storedRot = transform.rotation;
        currentNode.nextPos = storedPos;
        currentNode.nextRot = storedRot;
        while (currentNode != null)
        {
            currentNode.tail.transform.position = currentNode.nextPos;
            currentNode.nextPos = storedPos;
            storedPos = currentNode.tail.transform.position;
            currentNode.tail.transform.rotation = currentNode.nextRot;
            currentNode.nextRot = storedRot;
            storedRot = currentNode.tail.transform.rotation;
            currentNode = currentNode.next;
        }
        if (tailAddCount > 0)
        {
            addTail();
            tailAddCount--;
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            addTail();
            tailAddCount = tailGrowth;
        }
    }

    void addTail()
    {
        Quaternion rotation;
        Vector3 position;
        Vector3 position2;
        if (TailList.start == null)
        {
            rotation = transform.rotation;
            position = transform.position - transform.right * updateDist;
            position2 = transform.position;
            LL_Add(TailList, Instantiate(Tail_WithoutTrigger, position, rotation) as GameObject, position2, rotation);
        }
        else if (TailList.size <= 20)
        {
            rotation = TailList.end.tail.transform.rotation;
            position = TailList.end.tail.transform.position - TailList.end.tail.transform.right * updateDist;
            position2 = TailList.end.tail.transform.position;
            LL_Add(TailList, Instantiate(Tail_WithoutTrigger, position, rotation) as GameObject, position2, rotation);
        }
        else
        {
            rotation = TailList.end.tail.transform.rotation;
            position = TailList.end.tail.transform.position - TailList.end.tail.transform.right * updateDist;
            position2 = TailList.end.tail.transform.position;
            LL_Add(TailList, Instantiate(Tail_WithTrigger, position, rotation) as GameObject, position2, rotation);
        }
    }

    //Linked List
    public class Node
    {
        public Vector3 nextPos;
        public GameObject tail;
        public Node next;
        public Quaternion nextRot;
    }
    
    public class LinkedList
    {
        public Node start;
        public Node end;
        public int size;
    }

    public void LL_Add(LinkedList LL, GameObject newTail, Vector3 nextPos, Quaternion rotation)
    {
        Node toAdd = new Node();
        toAdd.nextPos = nextPos;
        toAdd.tail = newTail;
        toAdd.next = null;
        toAdd.nextRot = rotation;

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
