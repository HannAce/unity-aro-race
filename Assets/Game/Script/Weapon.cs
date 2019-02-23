using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrow;
    public float time;

    // Update is called once per frame


    void Update()
    {

            if (time >= 2)
            {
                time -= Time.deltaTime;
            }
            else
            {
                //Do Something after clock hits 0
                Shoot();
                time = time * time;
            }
        
        //Do Something else while clock counting down
    }

    void Shoot()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
    }
}
