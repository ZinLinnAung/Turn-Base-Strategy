using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    private Vector3 targetPosition;
    [SerializeField] private Animator animator;


    private void Awake()
    {
        targetPosition = transform.position;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float rotatespeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime*rotatespeed)  ;
            float speed = 4f;
            transform.position += moveDirection * speed * Time.deltaTime;
            animator.SetBool("running", true);
        }else
        {
            animator.SetBool("running", false);
        }

       
    }


   public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
    
