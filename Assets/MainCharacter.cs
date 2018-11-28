using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void AnimateAttack()
    {
        animator.Play("Attack");
    }

    public void LookAt(Vector3 lookAt)
    {
        transform.LookAt(lookAt);
        Vector3 angles = transform.eulerAngles;
        angles.x = 0;
        angles.z = 0;
        transform.eulerAngles = angles;
    }
}
