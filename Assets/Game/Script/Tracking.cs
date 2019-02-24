using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    GameObject target;
    public GameObject explosion;
    public float rotatespeed = 5f;

    Quaternion rotateToTarget;
    Vector3 dir;
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
        rotateToTarget = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotatespeed);
        rb.velocity = new Vector2(dir.x*2,dir.y*2);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }

}
