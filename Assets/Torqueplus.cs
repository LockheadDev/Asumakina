using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torqueplus : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb ;
    public float speed =5f;
    public Vector2 maxVelocity;
    public Vector2 minVelocity;
    public GameObject despawnEffect;
    public float torque;

    // Start is called before the first frame update
    void Start()
    {
        float x,y;
        x = Random.Range(minVelocity.x,maxVelocity.x);
        y = Random.Range(minVelocity.y,maxVelocity.y);
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Randomize(x),Randomize(y)) * speed;
    }

    float Randomize(float num)
    {
        int u = Random.Range(0,2);
        if(u==0)
        {
            num = -num;
        }
        if(u==1)
        {
        }
        return num;
    }
     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player plyr = hitInfo.GetComponent<Player>();
         if (plyr != null)
         {
             plyr.AddTorque(torque);
             Despawn();
         }
    }

    void Despawn()
    {
        Instantiate(despawnEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
