using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float speed=7f;

    private float moveInputx, moveInputy;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInputy = Input.GetAxisRaw("Vertical");
        moveInputx = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        if(Mathf.Abs(Input.GetAxisRaw("Vertical"))==1 && Mathf.Abs(Input.GetAxisRaw("Horizontal"))==1 ){
             rb.velocity = new Vector2(moveInputx*speed*Time.fixedDeltaTime/1.5F,moveInputy*speed*Time.fixedDeltaTime/1.5F);
        }else{
            rb.velocity = new Vector2(moveInputx*speed*Time.fixedDeltaTime,moveInputy*speed*Time.fixedDeltaTime);
        }
    }
    
}
