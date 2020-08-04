using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D rb ;
    public float speed =5f;
    public Vector2 maxVelocity;
    public Vector2 minVelocity;

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
}
