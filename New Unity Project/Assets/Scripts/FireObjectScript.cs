using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObjectScript : MonoBehaviour
{
    private const float livingTime = 10.0f;
    private float damage;
    private int force;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        this.damage = 1.0f;
        this.force = 600;
        this.startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= startTime + livingTime) {
            DestroyImmediate(gameObject);
        }
    }

    public void addDamage() {
        this.damage += 0.1f;
    }

    public void removeForce() {
        this.force -= 6;
    }
    
    void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.tag == "Destroyable") {
            collision.gameObject.GetComponent<DestroyableScript>().occultObject(this.damage);
        }
        Destroy(this.gameObject);
    }

    public int getForce() {
        return this.force;
    }

    public void printStatus() {
        Debug.Log("Collision");
        Debug.Log("Damage: " + damage);
        Debug.Log("Force: " + force);
    }
}