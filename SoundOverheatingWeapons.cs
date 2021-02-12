using UnityEngine;

[RequireComponent(typeof(OverheatedGun))]
public class SoundOverheatingWeapons : MonoBehaviour
{
    [SerializeField] private OverheatedGun _overheatedGun;
    [SerializeField] private AudioClip _overheat;
    [SerializeField] private AudioSource _audioSource;
    
    private void Play()
    {
        _audioSource.PlayOneShot(_overheat);
    }

    private void OnEnable()
    {
        _overheatedGun.WeaponOverheated += Play;
    }

    private void OnDisable()
    {
        _overheatedGun.WeaponOverheated -= Play;
    }
}