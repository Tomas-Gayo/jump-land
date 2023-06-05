using ScriptableObjectArchitecture;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [Header("Broadcasting On")]
    [SerializeField] private AudioClipRequestGameEvent audioRequest;

    public void PlayAudioTrigger(AudioClip clip)
    {
        var request = new AudioClipRequest(
            audioClip: clip
        );

        audioRequest!.Raise(request);
    }
}
