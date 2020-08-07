using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public int armor = 2;
    

    public GameObject deathAnimation;
    public float damageTimeAnimation =0.2f;

    private SpriteRenderer sr;
    private HealthPlyr hp;

    [HideInInspector]
    public bool isPoweredB; //Bullet

    [HideInInspector]
    public bool isPoweredA;  //shoot type

    [HideInInspector]
    public Weapon wp;

    private TimeManager tm;
    private DragNShoot dragNShoot;

   

    // Start is called before the first frame update
    void Start()
    {
        dragNShoot = GetComponent<DragNShoot>();
        tm = FindObjectOfType<TimeManager>();
        wp = GetComponent<Weapon>();
        if(wp == null) {Debug.Log("no weapon found");}
        sr = GetComponent<SpriteRenderer>();
        hp = FindObjectOfType<HealthPlyr>();
        if(hp == null)
        {
            Debug.Log("wat");
        }
        hp.numofhearts = 3;
        hp.health = health;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        tm.doSlowMotion();

        FindObjectOfType<SoundMng>().PlaySound("PlayerDamage");
        StartCoroutine(effectSprite(sr));
        if (armor<=0)
        {
            health -= damage;
            hp.health = health;
        }
        else
        {
            armor -= damage;
            hp.armorvalue = armor;
        }
    }

    public void AddTorque(float torq)
    {
        dragNShoot.AddTorque(torq);
    }

    
    
    public void Heal(int ht)
    {
        FindObjectOfType<SoundMng>().PlaySound("PlayerHeal");
        health += ht;
        hp.health = health;
    }

    public void GiveArmor(int arm)
    {
        FindObjectOfType<SoundMng>().PlaySound("PlayerArmor");
        armor += arm;
        hp.armorvalue = armor;
    }
    

    void Die()
    {
        SceneMng.setgameOver(true);
        Instantiate(deathAnimation, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("timesDead", PlayerPrefs.GetInt("timesDead")+1);
        Destroy(this.gameObject);
    }



    
    
    IEnumerator effectSprite(SpriteRenderer sr)
    {
        sr.color = new Color(100,0,0);
         
        yield return new WaitForSeconds(damageTimeAnimation);
         
        sr.color = new Color(255,255,255);
    }
     
    private void FixedUpdate()
    {
        hp.health = health;
        hp.armorvalue = armor;
        if (health <= 0)
        {
            Die();
        }
        
    }
    
    public int getHealth()
    {
        return health;
    }
    public int getArmor()
    {
        return armor;
    }
}
