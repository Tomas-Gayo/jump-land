using UnityEngine;
using UnityEngine.Audio;

public class SetAudioVolume : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        audioMixer.SetFloat("Volume", GetVolume());
    }

    public void SetVolume(float volume) => audioMixer.SetFloat("Volume", volume);

    private float GetVolume()
    {
        bool result = audioMixer.GetFloat("Volume", out float volume);

        volume = result ? volume : 0;

        return volume;
    }
}
