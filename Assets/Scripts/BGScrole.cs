﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrole : MonoBehaviour
{
    public float scrollSpeed = -2f;
    private Rigidbody2D rb2d;
    public bool gameOver = false;

    // Use this for initialization
    void Start () 
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        rb2d.velocity = new Vector2 (scrollSpeed, 0);
    }

    void Update()
    {
        // If the game is over, stop scrolling.
        if(gameOver == true)
        {
           
            rb2d.velocity = Vector2.zero;
        }
    }
}
