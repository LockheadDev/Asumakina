using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int health = 100;
    public GameObject deathEffect;
    public int atack = 1;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = transform.right*-speed;
    }
    

    public void TakeDamage(int damage)
    {
       FindObjectOfType<SoundMng>().PlaySound("EnemyDamage");
        StartCoroutine(damageSprite());
        
       
        health -= damage;
        if (health <=0)
        {
            
            Die();
        }
    }

     void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Score.scoreValue += 20;
        PlayerPrefs.SetInt("enemiesKO", PlayerPrefs.GetInt("enemiesKO")+1);
    }

     void OnTriggerEnter2D(Collider2D hitInfo)
     {
         Player plyr = hitInfo.GetComponent<Player>();
         if (plyr != null)
         {
             plyr.TakeDamage(atack);
             
         }
     }

     IEnumerator damageSprite()
     {
         sr.color = new Color(100,0,0);
         
         yield return new WaitForSeconds(0.1F);
         
         sr.color = new Color(255,255,255);
     }
     
     
}