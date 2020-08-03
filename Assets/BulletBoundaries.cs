using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoundaries : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector2 screenBounds;
    public float range = 1F;
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
        if (Mathf.Abs(transform.position.x) >screenBounds.x+range||Mathf.Abs(transform.position.y)> screenBounds.y+range)
        {
            Destroy(gameObject);
        }
    }
}
