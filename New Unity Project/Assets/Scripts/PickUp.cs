﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Vector3 objectPos;
    public float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;
    public float pickUpDistance = 1f;

    private void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if(!canInteract())
        {
            isHolding = false;
        }

        if (isHolding)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);
        } else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    public bool Interact()
    {
        if (!isHolding)
        {
            if (canInteract())
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().detectCollisions = true;
            }
            else return false;
        }

        isHolding = !isHolding;
        return true;

    }
    public bool canInteract()
    {
        return distance <= pickUpDistance;
    }
}
