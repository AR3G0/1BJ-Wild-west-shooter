using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback_fx : MonoBehaviour
{

    public AudioClip[] clips;
    public bool w;
    public bool innocentKilled;

    // Start is called before the first frame update
    void Start()
    {
        if (w)
        {
            int trackNum = Random.Range(6, 9);
            AudioSource.PlayClipAtPoint(clips[trackNum], transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
