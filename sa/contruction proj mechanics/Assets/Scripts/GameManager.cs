using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool ispaused;
    public Text scoreText;
    public float scoreCount;

    //bool collwithBox; 
    public BallMovement bM;
    public PlayerControl playerControlScript;

    public GameObject backgroundQuad;
    public float bgSpeed;
    Renderer bgRend;

   
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        bgRend = backgroundQuad.GetComponent<MeshRenderer>();
        bM = GameObject.Find("THORNWHELL").GetComponent<BallMovement>();
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();

    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0);

        /*if (playerControlScript.collwithBox == true)
        {
            bM.distanceToMoveFunc();
        }*/
        /*if(playerControlScript.speed == 0)
        {
            bgRend.material.mainTextureOffset = new Vector2(0, 0);

        }*/
    }
    void FixedUpdate()
    {
        /*if (playerControlScript.collwithBox == true)
        {
            bM.distanceToMoveFunc();
        }*/

    }

}
