using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestructor : MonoBehaviour
{
    public GameObject platformDestrucionPoint;
    
    void Start()
    {
        platformDestrucionPoint = GameObject.Find("PlatformDestructionPoint"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformDestrucionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
