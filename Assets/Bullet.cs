using System;

using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 40;

    public Rigidbody2D rb;

    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        
                rb.velocity = transform.up * speed ;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }
}
