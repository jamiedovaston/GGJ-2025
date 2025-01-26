using UnityEngine;

// ADD TO ANIM EVENT
public class PlayFootstep : StateMachineBehaviour
{
    public void PlaySound()
    {
        SoundManager.PlaySound(SoundType.FOOTSTEP);
    }
}
