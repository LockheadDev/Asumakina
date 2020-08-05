using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_once : MonoBehaviour
{
    public float time = 0.1F;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAnim",time);
    }

    void DestroyAnim()
    {
        Destroy(this.gameObject);
    }
}
