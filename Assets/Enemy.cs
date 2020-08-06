using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public int atack = 1;


    public void TakeDamage(int damage)
    {
       FindObjectOfType<SoundMng>().PlaySound("EnemyDamage");
        
       
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
             Die();
         }
     }

     
     
}