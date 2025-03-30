using StarterAssets;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    private StarterAssetsInputs starterAssetsInputs;
    private Vector2 moveInput;
    private bool sprintInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();

    }

    // Update is called once per frame
    void Update()
    {
        if(starterAssetsInputs != null)
        {
            moveInput = starterAssetsInputs.move;
            sprintInput = starterAssetsInputs.sprint;
        }

        if ((moveInput.x != 0) || (moveInput.y != 0))
        { 
            animator.SetBool("isWalking", true);
        }
        if ((moveInput.x == 0) && (moveInput.y == 0))
        {
            animator.SetBool("isWalking", false);
        }

        if (sprintInput == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
