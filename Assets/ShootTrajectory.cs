using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrajectory : MonoBehaviour
{
    public LineRenderer line;
    public Transform anchorTransform;

    void Awake()
    {
        line = GetComponent<LineRenderer>();

        if (line ==null)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
    }
    public void DrawShootingTrajectory(Vector3 shootpower,Vector3 startpoint)
    {
        line.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = anchorTransform.position;
        points[1] = startpoint - Vector3.Reflect(shootpower,new Vector3(0,0,0));
        line.SetPositions(points);
    }
     public void endTrajectory()
    {
        line.positionCount = 0;
    }
    // Start is called before the first frame update
}
