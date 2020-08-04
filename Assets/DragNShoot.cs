using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power =10f;
    public Rigidbody2D rb ;
    public Vector2 minPower;
    public Vector2 maxPower;
    private TrajectoryLine tl;
    private Transform tr;
    public TimeManager tm;

    

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
        tr = GetComponent<Transform>();
        tm = FindObjectOfType<TimeManager>();
        if(tr==null)
        {
            Debug.Log("Transform not found");
        }
        if(tl == null)
        {
            Debug.Log("TrajectoryLinenot found");
            return;
        }
        if(tm == null)
        {
            Debug.Log("TimeManager not found");
            return;
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        //Display angular velocity;
        FindObjectOfType<TextPopUP>().setInfo(rb.angularVelocity.ToString());
        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z =15;
        }
        if(Input.GetMouseButton(0))
        {
            //Slowmo Effect
            tm.doSlowMotion();


            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            //rb.AddTorque(Mathf.Sqrt((Mathf.Pow(startPoint.x-currentPoint.x,2)+Mathf.Pow(startPoint.y-currentPoint.y,2)))/50);
            tr.eulerAngles = new Vector3(0,0,50*Mathf.Sqrt((Mathf.Pow(startPoint.x-currentPoint.x,2)+Mathf.Pow(startPoint.y-currentPoint.y,2))));
            tl.RenderLine(startPoint,currentPoint);
        }
         if(Input.GetMouseButtonUp(0))
        {

            Time.timeScale =1F;
            tl.EndLine();
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z =15;


            force = new Vector2(Mathf.Clamp(startPoint.x-endPoint.x,minPower.x,maxPower.x),Mathf.Clamp(startPoint.y-endPoint.y,minPower.y,maxPower.y));
            rb.AddForce(force*power,ForceMode2D.Impulse);
        }
    }
}
