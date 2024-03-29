﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power =10f;
    public Rigidbody2D rb ;
    public Vector2 minPower;
    public Vector2 maxPower;
    public TrajectoryLine shootguide;
    private TrajectoryLine tl;
    private Transform tr;
    public TimeManager tm;
    public TrailRenderer trail;
    public float angVel = 30f; 
    private TimeBar timeBar;
    public bool disableControls = false;


    

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3[] trailpos;
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
        tr = GetComponent<Transform>();
        tm = FindObjectOfType<TimeManager>();
        timeBar = FindObjectOfType<TimeBar>();
        if(tr==null)
        {
            Debug.Log("Transform not found");
            return;
        }
        if(tl == null)
        {
            Debug.Log("TrajectoryLine not found");
            return;
        }
        if(tm == null)
        {
            Debug.Log("TimeManager not found");
            return;
        }
        if(trail==null)
        {
            Debug.Log("Trail not found");
            return;
        }

    }

    void ClearTrailPos(Vector3[] array)
    {
        for (int i=0; i<array.Length;i++)
        {
            array[i] = transform.position;
        }
    }

    public void AddTorque(float force)
    {
        rb.AddTorque(force);
    }

    public void FillTimeBar()
    {
        timeBar.FillTimeBar();
    }

    public void CleanControls()
    {
        trail.Clear();
        tl.EndLine();
        timeBar.isConsuming = false;
    }

    void Update()
    {
        //Display angular velocity;
        FindObjectOfType<TextPopUP>().setInfo(rb.angularVelocity.ToString());
        //getting trail render positions
        Vector3[] testval= new Vector3[trail.positionCount];
        trail.GetPositions(testval);
        if(!timeBar.isConsumeEnabled)
        {
            disableControls = true;
            CleanControls();
        }
        else if(timeBar.isConsumeEnabled&&!FindObjectOfType<GeneralControl>().onPause)
        {
            disableControls = false;
        }

        //Controls
        if(!disableControls)
        {
            //CLICK DERECHO
            if(Input.GetMouseButtonDown(1))
            {
               //FindObjectOfType<AudioChanger>().ChangeMusicPitch(0.5F);
            }
            if(Input.GetMouseButton(1))
            {
                tm.doSlowMotion();
                rb.velocity = new Vector3(0,0,0);
               
                timeBar.isConsuming = true;
            }
            if(Input.GetMouseButtonUp(1))
            {
                FindObjectOfType<SoundMng>().PlaySound("Teleport1");
                FindObjectOfType<TrailEffector>().Burst(testval);
                transform.position = testval[0];
                 trail.Clear();
               timeBar.isConsuming = false;
                FindObjectOfType<SoundMng>().Stop("SlowDown");
                //FindObjectOfType<AudioChanger>().RestartMusicPitch();
            }

        //CLICK IZQUIERDO
        if(Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<SoundMng>().PlaySound("Drag");
            rb.velocity = new Vector3(0,0,0);
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z =15;
        }
        if(Input.GetMouseButton(0))
        {
            tm.doSlowMotion();
            timeBar.isConsuming = true;
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            rb.angularVelocity= (Mathf.Sqrt((Mathf.Pow(startPoint.x-currentPoint.x,2)+Mathf.Pow(startPoint.y-currentPoint.y,2)))*angVel);
            tr.eulerAngles = new Vector3(0,0,50*Mathf.Sqrt((Mathf.Pow(startPoint.x-currentPoint.x,2)+Mathf.Pow(startPoint.y-currentPoint.y,2))));
            //tl.RenderLine(startPoint,currentPoint);
            Vector3 wut = (transform.position-(startPoint-currentPoint));
            //wut = new Vector3(-wut.x,-wut.y,wut.z);
            shootguide.RenderLine(transform.position,wut);

        }

         if(Input.GetMouseButtonUp(0))
        {
            tm.Resume();
            timeBar.isConsuming = false;
            tl.EndLine();
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z =15;
            force = new Vector2(Mathf.Clamp(startPoint.x-endPoint.x,minPower.x,maxPower.x),Mathf.Clamp(startPoint.y-endPoint.y,minPower.y,maxPower.y));
            rb.AddForce(force*power,ForceMode2D.Impulse);
            FindObjectOfType<SoundMng>().Stop("SlowDown");
        }
        }
    }
}
