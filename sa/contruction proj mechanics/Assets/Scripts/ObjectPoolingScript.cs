using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingScript : MonoBehaviour
{
    public GameObject platform;
    //public GameObject[] platform;
    public int platformCount;

    List<GameObject> platformList;
    
    // Start is called before the first frame update
    void Start()
    {
        platformList = new List<GameObject>();
        
        for(int i = 0; i < platformCount; i++)
        {
            //GameObject obj = (GameObject)Instantiate(platform[Random.Range(0,platform.Length)]);
            GameObject obj = (GameObject)Instantiate(platform);
            obj.SetActive(false);
            platformList.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i<platformList.Count; i++)
        {
            if(!platformList[i].activeInHierarchy)
            {
                return platformList[i];
            }
        }

        //GameObject obj = (GameObject)Instantiate(platform[Random.Range(0,platform.Length)]);
        GameObject obj = (GameObject)Instantiate(platform);
        obj.SetActive(false);
        platformList.Add(obj);
        return obj;
    }

}
