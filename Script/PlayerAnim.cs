using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Jump");
        if (dirX != 0) transform.localScale = new Vector3(dirX > 0 ? 1 : -1, 1, 1);

        if (dirX != 0)
        {
            animator.SetInteger("State", 1);
        }
        else {
            animator.SetInteger("State", 0);
        }

        if (dirY != 0) 
        {
            animator.SetInteger("State", 2);
        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }
}
