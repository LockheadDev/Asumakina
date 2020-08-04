using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objects;
    private Vector2  spawnValues;
    public float spawnWait;
    public float spawnLeastWait;
    public float spawnMostWait;
    public int minSpawnAtOneTime;
    public int maxSpawnAtOneTime;
    public int startWait;
    public bool stop;
    private int randObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());

    }

    // Update is called once per frame
    void Update()
    {
        spawnValues = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        spawnWait = Random.Range(spawnLeastWait,spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while(!stop)
        {
            int quantity = Random.Range(minSpawnAtOneTime,maxSpawnAtOneTime);
            for(int i = 0; i<=quantity;i++){
            randObject = Random.Range(0, objects.Length);
            Vector2 spawnPostition = new Vector2(Random.Range(-spawnValues.x,spawnValues.x),Random.Range(-spawnValues.y,spawnValues.y));
            Instantiate(objects[randObject],spawnPostition,Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
