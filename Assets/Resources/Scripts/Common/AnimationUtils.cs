using UnityEngine;

namespace Common
{
    public static class AnimationUtils
    {
        public static float GetAnimationLength(Animator animator, string animationName)
        {
            foreach (var clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name == animationName)
                {
                    return clip.length;
                }
            }

            return -1f;
        }
    }
}