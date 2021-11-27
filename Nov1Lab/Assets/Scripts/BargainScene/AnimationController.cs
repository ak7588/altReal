using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject NPC;
    Animator animator;

    private void Awake()
    {
        animator = NPC.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Talk"))
        {
            animator.SetBool("isTalking", true);
            StartCoroutine("NPCTalking");
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    animator.SetBool("isTalking", true);
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    animator.SetBool("isTalking", false);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Talk"))
    //    {
    //        animator.SetBool("isTalking", false);
    //    }
    //}

    IEnumerator NPCTalking()
    {
        // play audio
        yield return new WaitForSeconds(10);
        animator.SetBool("isTalking", false);
        yield return null;
    }
}
