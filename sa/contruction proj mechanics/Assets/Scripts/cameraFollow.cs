using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    private float distancetoMove;
    private Vector3 lastPlayerPosition;
    void Start()
    {
        lastPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distancetoMove = player.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distancetoMove, transform.position.y, transform.position.z);

        lastPlayerPosition = player.transform.position;
    }
}
