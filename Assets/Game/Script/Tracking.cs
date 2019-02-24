using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    GameObject target;
    public float rotatespeed = 5f;

    Quaternion rotateToTarget;
    Vector2 dir;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Anim_Ace");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle,Vector3.forward), Time.deltaTime * rotatespeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);
        rb.velocity = new Vector2(dir.x*2,dir.y*2);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }

}
