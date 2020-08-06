using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed=5f;
    public float stoppingDistance;
    private Transform target;
    private bool targetexists=true;
    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(target==null)
        {
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(target==null)
        {
            targetexists=false;
        }
        if(!targetexists)
        {
            transform.position =Vector2.MoveTowards(transform.position,new Vector2(0,0),speed*Time.deltaTime);
        }else if(targetexists){
        if(Vector2.Distance(transform.position,target.position)>stoppingDistance)
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        }
        
    }
}
