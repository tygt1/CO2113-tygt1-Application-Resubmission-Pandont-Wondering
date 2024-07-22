using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAIController : Character
{
    public Animator animator;

    [SerializeField]
    private float movementForce = 5f;
    [SerializeField]
    private float jumpForce = 16f;
    [SerializeField]
    private float maxSpeed = 25f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private Camera playerCamera;
    private GameObject Hurtbox;


    [SerializeField]
    private float minActionWaitTime = 1f;
    [SerializeField]
    private float maxActionWaitTime = 5f;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();

        animator = this.GetComponent<Animator>();
        //Movement is based from where object is to the camera.
        //Assigns the camera when intialised
        playerCamera = Camera.main;
        Hurtbox = this.transform.Find("Hurtbox").gameObject;
    }

    private void Start()
    {
        matchStarted = true;
        StartCoroutine(DoRandomActions());
    }

    private void FixedUpdate()
    {
        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;


        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;


        // Limit horizontal speed
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        // Handle character death
        if (matchStarted && !characterDead && health <= 0)
        {
            characterDead = true;
            OnCharacterDeath();
        }
    }



    private IEnumerator DoRandomActions()
    {
        while (!characterDead)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minActionWaitTime, maxActionWaitTime));
            DoRandomAction();
        }
    }


    private void DoRandomAction()
    {
        float actionIndex = UnityEngine.Random.Range(0, 4); // Assuming 4 different actions

        switch (actionIndex)
        {
            case 0:
                DoJump();
                break;
            case 1:
                DoPunch();
                break;
            case 2:
                DoKick();
                break;
            case 3:
                DoBlock();
                break;
            default:
                break;
        }

        float randomValue = UnityEngine.Random.Range(0f, 1f);
        if (randomValue < 0.9f)
        {
            DoMove();
        }
    }


    private void DoJump()
    {
        if (OnGround())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool OnGround()
    {
        Vector3 rayOrigin = this.transform.position + Vector3.up * 0.25f;
        Ray ray = new Ray(rayOrigin, Vector3.down);
        const float rayDistance = 1.25f;
        return Physics.Raycast(ray, out RaycastHit hit, rayDistance);
    }

    private void DoPunch()
    {
        animator.SetTrigger("punch");
    }

    public bool isPunching()
    {
        return animator.GetCurrentAnimatorStateInfo(1).IsName("Punching");
    }

    private void DoKick()
    {
        animator.SetTrigger("kick");
    }

    public bool isKicking()
    {
        return animator.GetCurrentAnimatorStateInfo(2).IsName("Kicking");
    }

    private void DoBlock()
    {
        bool isBlocking = animator.GetBool("blocking");
        animator.SetBool("blocking", !isBlocking);
        Hurtbox.SetActive(!isBlocking);
    }

    private void DoMove()
    {
        // Generate a random direction on the X axis
        float randomDirectionX = UnityEngine.Random.Range(-1f, 1f);

        for (int repeatFiveTimesIndex = 0; repeatFiveTimesIndex < 5; repeatFiveTimesIndex++)
        {
            // Convert the random direction to be relative to the camera's position
            Vector3 relativeDirection = GetCameraRight(playerCamera) * randomDirectionX;
            forceDirection += relativeDirection * movementForce;
        }
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void OnCharacterDeath()
    {
        animator.SetTrigger("dead");
        movementForce = 0f;
        maxSpeed = 0f;
        jumpForce = 0f;
    }
}
