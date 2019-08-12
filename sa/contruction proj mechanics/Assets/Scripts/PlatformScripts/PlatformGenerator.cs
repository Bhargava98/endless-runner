using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platforms;
    public Transform generationPoint;
    public float distancebtwPlatforms;
    //public int distancebtwMin;
    //public int distancebtwMax;

    private float[] platformWidths;
    private int platformSelector;
    //private int distanceBetween;

    public ObjectPoolingScript[] theObjectPool;
     


    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = platforms.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPool.Length];

        for (int i = 0; i < theObjectPool.Length; i++)
        {
            platformWidths[i] = theObjectPool[i].platform.GetComponent<BoxCollider2D>().size.x;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            //distanceBetween = Random.Range(distancebtwMin, distancebtwMax);
            platformSelector = Random.Range(0, theObjectPool.Length);

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distancebtwPlatforms, 
                                              transform.position.y,transform.position.z);

            //Instantiate(platforms, transform.position, Quaternion.identity);

            GameObject newPlatform =  theObjectPool[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }

    }
}
