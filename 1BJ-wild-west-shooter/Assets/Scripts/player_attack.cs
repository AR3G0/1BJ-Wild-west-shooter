using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public float timer = 0f;
    public float speed;
    public Sprite gunFired;

    private SpriteRenderer spriteComponent;

    private void Start()
    {
        spriteComponent = GetComponent<SpriteRenderer>();
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
            spriteComponent.sprite = gunFired;
        }
    }
}
