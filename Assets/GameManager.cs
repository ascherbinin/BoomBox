using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public float radius = 0;
    public float power = 0;
	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Vector3 explosionPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            explosionPos.z = 0;
            Debug.Log("Boom in " + explosionPos);
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            Debug.Log("Colliders count: " + colliders.Length);
            foreach (Collider hit in colliders)
            {
                if ((hit.gameObject.tag == "Crate" ||
                    hit.gameObject.tag == "MainCrate") &&
                    hit.GetComponent<Rigidbody>())
                { 
                    Debug.Log("BOOM: " + hit.gameObject.name);
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
            }
        }
    }
}
