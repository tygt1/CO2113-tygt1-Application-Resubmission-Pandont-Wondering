using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class StoryModeMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject characterNPC;


    public Animator animator;
    
    public NavMeshAgent navMeshAgent;
    
    public Transform destination;

    [SerializeField]
    public PlayableDirector timeline;

    public Boolean moving = false;

    void Awake()
    {

    }

    void Update()
    {
        if (moving == true)
        {
            float speed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
            animator.SetFloat("speed", speed);

            if (transform.position.z == destination.position.z)
            {
                timeline.Play();
                moving = false;
            }
        }
    }

    public void MoveCharacter()
    {
        animator = characterNPC.GetComponent<Animator>();
        navMeshAgent = characterNPC.GetComponent<NavMeshAgent>();

        navMeshAgent.SetDestination(destination.position);
        moving = true;
    }
}
