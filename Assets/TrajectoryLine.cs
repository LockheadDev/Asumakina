using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer lr ;
    void Awake()
    {
     lr = GetComponent<LineRenderer>();   
    }

    public void RenderLine(Vector3 startpoint, Vector3 endpoint)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[1] = startpoint;
        points[0] = endpoint;

        lr.SetPositions(points);
    }
    public void EndLine()
    {
        lr.positionCount =0;
    }
}
