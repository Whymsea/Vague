using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    public GameObject projectilePrefab;
    public Transform shootPoint;

    // Update is called once per frame
    void Start(){

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the input you want to use for shooting
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new projectile at the shootPoint position and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
    }

    public void Shot()
    {
        UnityEngine.Debug.Log("piou piou");
    }
}

