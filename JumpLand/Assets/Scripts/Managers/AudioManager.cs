using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundEffectSource;

    public void PlayBackgroundMusic(AudioClipRequest request)
    {
        musicSource.clip = request.audioClip;
        musicSource.Play();
    }

    public void PlaySoundEffect(AudioClipRequest request)
    {
        soundEffectSource.clip = request.audioClip;
        soundEffectSource.Play();
    }
}
