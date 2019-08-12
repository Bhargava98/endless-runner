using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public float bgSpeed;
    public Renderer bgRend;
    // Start is called before the first frame update
    void Start()
    {
        bgRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0);
    }
}
