using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [SerializeField]
    private float speed = 6;

    [SerializeField]
    private float health = 100;

    Vector3 direction = Vector3.zero;

    private Animator animator;

    //before start
    private void Awake()
    {
        Debug.Log(System.DateTime.Now.ToString("HH:mm:ss:FFF") + "; Player Control Script AWAKE");
    }

    // Use this for initialization
    void Start()
    {
        try
        {
            animator = this.GetComponent<Animator>();
        }
        catch (Exception)
        { }
        Debug.Log(System.DateTime.Now.ToString("HH:mm:ss:FFF") + "; Player Control Script START");
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");

        direction.y = Input.GetAxis("Vertical");

        Vector3 movement = (direction * speed) * Time.deltaTime;

        transform.Translate(movement);

        if (animator != null)
        {
            AnimationUpdate();
        }
    }

    private void AnimationUpdate()
    {
        if (direction.y > 0)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (direction.y < 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (direction.x < 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (direction.x > 0)
        {
            animator.SetInteger("Direction", 3);
        }
    }

    public void ReduceHealth(float dmg)
    {
        if ((health - dmg) >= 0)
        {
            health -= dmg;
        }
        else
        {
            health = 0;
        }
        Debug.Log(System.DateTime.Now.ToString("HH:mm:ss:FFF") + "; Health:" + health);
    }
}
