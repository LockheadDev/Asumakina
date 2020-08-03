using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesOptimization : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        //Optimization code
        if ((sr.size.x/2)+transform.position.x < -screenBounds.x )
        {
            Destroy(gameObject);
        }
    }
}
