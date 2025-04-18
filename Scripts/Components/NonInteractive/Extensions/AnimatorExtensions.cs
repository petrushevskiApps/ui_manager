using UnityEngine;

namespace MenuManager.Scripts.Components.NonInteractive.Extensions
{
    public static class AnimatorExtensions
    {
        public static void SetTriggerState(this Animator animator, string triggerState)
        {
            if (string.IsNullOrEmpty(triggerState))
            {
                animator.enabled = false;
                return;
            }
            animator.enabled = true;
            animator.SetTrigger(triggerState);
        }
    }
}