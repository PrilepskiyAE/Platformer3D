using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void WalkRight(bool value)
    {
        animator.SetBool("WalkRight", value);
    }

    public void WalkLeft(bool value)
    {
        animator.SetBool("WalkLeft", value);
    }

     public void GroundAnimation(bool value)
    {
        animator.SetBool("Ground", value);
    }

        public void GunAnimation(bool value)
    {
        animator.SetBool("Shoot",value);
    }
 
}