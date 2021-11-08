using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBotController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isWalking", true);
        transform.position += transform.forward * Time.deltaTime;
    }
}
