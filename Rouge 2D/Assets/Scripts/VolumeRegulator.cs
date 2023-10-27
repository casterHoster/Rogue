using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Signaling))]

public class VolumeRegulator : MonoBehaviour
{
    [SerializeField] private float _speedChange;

    private Signaling _signaling;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
        _signaling = GetComponent<Signaling>();
    }

    public IEnumerator ChangeVolume(float targeVolume)
    {
        while (_audioSource.volume != targeVolume)
        {
            _audioSource.volume = Mathf.MoveTowards( _audioSource.volume, targeVolume,  _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}
