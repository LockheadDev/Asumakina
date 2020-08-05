using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffector : MonoBehaviour
{
    public GameObject burstEffector;

    public void Burst(Vector3[] verts)
    {

        for(int i =0; i<verts.Length; i= i+16)
        {
            Instantiate(burstEffector,verts[i],Quaternion.Euler(0,0,Random.Range(0,360f)));
        }
    }
}
