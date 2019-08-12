using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    GameManager gameManager;
    public float Espeed;
    Rigidbody2D rb;

    public Vector3 rotationDirection;
    public GameObject player;
    PlayerControl playerControlScript;

    public Vector2 distanceToMove;
    public float ballMinusPlayerDistance;

    private float distancetoPlayer;
    
    private float timeStartedLerping;
    public float lerpTime;

    private bool shouldLerp = false;

    private Vector2 startPosition;
    private Vector2 endPosition;
    Renderer rend;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();

        playerControlScript = player.GetComponent<PlayerControl>();

        startPosition = transform.position;

        timeStartedLerping = Time.time;
        distancetoPlayer = Vector2.Distance(transform.position, player.transform.position) - ballMinusPlayerDistance;
        distanceToMove = new Vector2(distancetoPlayer, transform.position.y);
  
        shouldLerp = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.ispaused == false)
        {
            transform.Rotate(-rotationDirection);

            if (playerControlScript.isCollidingwitheWall == true)
            {
                Debug.Log("isCollidingwall bool is working");
                Lerp(transform.position, distanceToMove, timeStartedLerping, lerpTime);
            }

            rb.velocity = new Vector2(Espeed, rb.velocity.y);
        }
    }

    public Vector3 Lerp( Vector3 start, Vector3 end, float timestartedLerping, float lerpTime)
    {
        
        float timeSinceStarted = Time.time - timestartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        Vector3 result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }

    /* public void distanceToMoveFunc()
     {
         //transform.position = new Vector3(distance + distanceToMove, transform.position.y, transform.position.z);
         //transform.position = Vector3.MoveTowards();
         transform.position = Vector2.MoveTowards(transform.position, player.position, distanceToMove * Time.deltaTime);

         //Debug.Log("distancetoMoveFunc is called");
     }*/

    private void OnBecameInvisible()
    {
        Espeed += 5;
    }

    private void OnBecameVisible()
    {
        Espeed -= 5;
    }
}
