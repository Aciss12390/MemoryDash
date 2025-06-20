using UnityEngine;

public class RobotAnimatorController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetInteger("Direction", 0);
        }
        // Down
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetInteger("Direction", 1);
        }
        // Left
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("Direction", 2);
        }
        // Right
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("Direction", 3);
        }
    }
}
