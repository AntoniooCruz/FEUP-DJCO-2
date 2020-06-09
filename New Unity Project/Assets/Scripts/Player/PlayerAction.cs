﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{

    private EarthController earthController;
    private WindController windController;
    private FireController fireController;
    private WaterController waterController;

    private float maxPickUpDistance;


    private bool isHoldingObject = false;
    void Start()
    {
        earthController = GetComponent<EarthController>();
        windController = GetComponent<WindController>();
        fireController = GetComponent<FireController>();
        waterController = GetComponent<WaterController>();
        maxPickUpDistance = 3;
    }

    RaycastHit getObjectHit()
    {

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        return hit;
    }

    public void interactWithObject()
    {
        RaycastHit hit = getObjectHit();

        if (hit.collider == null)
            return;

        if (hit.transform.gameObject.layer != LayerMask.NameToLayer("MoveableObject"))
            return;

        if (hit.distance > maxPickUpDistance)
            return;

        isHoldingObject = hit.transform.gameObject.GetComponent<PickUp>().Interact();

    }
    public void startElement(Element element)
    {

        if (isHoldingObject)
            return;


        if (element == Element.Earth)
        {
            RaycastHit hit = getObjectHit();

            if (hit.collider == null)
                return;

            earthController.handleStart(hit);
        }

        else if (element == Element.Fire)
        {
            RaycastHit hit = getObjectHit();

            if (hit.collider == null)
                return;

            fireController.handleStart();
        }

        else if (element == Element.Water)
        {
            RaycastHit hit = getObjectHit();

            if (hit.collider == null)
                return;

            waterController.handleStart(hit);
        }

    }

    public void chargeElement(Element element)
    {
        if (isHoldingObject)
            return;


        if (element == Element.Wind)
        {
            RaycastHit hit = getObjectHit();

            if (hit.collider == null)
                return;

            windController.handleCharge(hit);
        }
        else if (element == Element.Fire)
        {
            RaycastHit hit = getObjectHit();

            fireController.handleCharge();
        }
        else if (element == Element.Water)
        {
            RaycastHit hit = getObjectHit();

            if (hit.collider == null)
                return;

            waterController.handleCharge(hit);
        }
    }

    public void releaseElement(Element element)
    {
        if (isHoldingObject)
            return;

        RaycastHit hit = getObjectHit();

        if (element == Element.Fire)
        {
            fireController.handleRelease(hit);
        }
        else if (element == Element.Water)
        {
            if (hit.collider == null)
                return;

            waterController.handleRelease(hit);
        }

    }


}
