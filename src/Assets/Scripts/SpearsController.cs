using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearsController : MonoBehaviour
{
    Collider2D cd;
    void Start()
    {
        cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKillerTag()
    {
        gameObject.tag = "MSpears";
        cd.isTrigger = false;
    }

    public void SetDefaultTag()
    {
        gameObject.tag = "Untagged";
        cd.isTrigger = true;

    }
}
