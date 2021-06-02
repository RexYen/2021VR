using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingControl : MonoBehaviour
{
    private Animator animator;
    public int A = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        A++;
        if (A > 100 && 450 > A)
        {
            animator.SetBool("Attack", true);
        }
        if (A > 450 && 800 > A)
        {
            animator.SetBool("Attack", false);
        }
        if (A > 800)
        {
            A = 0;
        }

    }

}
