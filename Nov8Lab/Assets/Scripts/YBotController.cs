using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YBotController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    int isWalkingHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    private void Update()
    {
        Vector3 velocity = agent.velocity;
        bool isMoving = velocity.magnitude > 0.01f && agent.remainingDistance > agent.radius;
        animator.SetBool(isWalkingHash, isMoving);
        velocity = transform.InverseTransformDirection(velocity);
        animator.SetFloat("VelocityX", velocity.x);
        animator.SetFloat("VelocityZ", velocity.z);
    }
}
