/*
 * Chris Smith
 * Assignment53D
 * Controls rifle shooting raycasts
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycasts : MonoBehaviour
{
    //Reference to player camera
    public Camera cam;
    //Reference to muzzle flash particle system
    public ParticleSystem muzzleFlash;
    //Rifle vars
    public float damage = 10f;
    public float range = 100f;
    public float hitForce = 10f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hitInfo;
        //If ray hits, get info
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            //Get Target script from hit object
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();
            //If object has the target script, cause it to take damage
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //Apply a force to a rigid body
            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }


    }
}
