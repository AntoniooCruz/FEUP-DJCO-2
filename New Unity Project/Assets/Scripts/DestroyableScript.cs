﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableScript : MonoBehaviour
{
    
    [FMODUnity.EventRef]
    private string DestroyEvent = "event:/main SFX/SFX #1/fire/destroy_stones_export";
    FMOD.Studio.EventInstance destroy;
	
    private UserSettings userSettings;
    
    public float racio = 1.5f;
    private float occultTime = 0.0f;
    public GameObject[] childs = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        userSettings = ManageUserSettings.LoadUserSettings();
        if (userSettings.sound.getSound("playerSounds"))
        {
            destroy = FMODUnity.RuntimeManager.CreateInstance(DestroyEvent);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        userSettings = ManageUserSettings.LoadUserSettings();
        if (userSettings.sound.getSound("playerSounds"))
        {
            destroy.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        }

        if (occultTime > 0)
        {
			
            for (int i = 0; i < 6; i++)
            {
                childs[i].GetComponent<MeshRenderer>().enabled = false;
                childs[i].GetComponent<MeshCollider>().enabled = false;
                if(i == 5)
                    StartCoroutine(ActivationRoutine(childs[i], true));
                else
                    StartCoroutine(ActivationRoutine(childs[i],false));
            }
            
        }
    }

    public void occultObject(float damage)
    {
        this.occultTime = racio * damage;
		destroy.start();

    }

    IEnumerator ActivationRoutine(GameObject child,bool isColliding)
    {
        yield return new WaitForSeconds(occultTime);
        child.GetComponent<MeshRenderer>().enabled = true;
        if(isColliding)
            child.GetComponent<MeshCollider>().enabled = true;
        occultTime = 0.0f;
    }
}
