using UnityEngine;

public class OpenSlidingWall : MonoBehaviour
{
    public Animator wallAnimator;

    private void OnTriggerEnter(Collider other)
    {
        wallAnimator.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        wallAnimator.SetBool("isOpen", false);
    }
}
