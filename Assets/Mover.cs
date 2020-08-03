using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D rb ;
    public float speed =5f;
    // Start is called before the first frame update
    void Start()
    {
        float x,y;
        x = Random.Range(-1,1.1F);
        y = Random.Range(-1,1.1F);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x,y) * speed;
        Debug.Log("Where is speed");
    }
}
