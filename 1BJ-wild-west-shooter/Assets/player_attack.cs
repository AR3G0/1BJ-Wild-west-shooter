using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public float timer = 0f;
    public float speed;
    public Sprite gunFired;

    private SpriteRenderer spriteComponet;

    private void Start()
    {
        spriteComponet = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 60 * speed * Time.deltaTime)
        {
            timer += 1 * Time.deltaTime;
        }
        else
        {
            spriteComponet.sprite = gunFired;
        }
    }
}
