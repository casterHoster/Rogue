using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent (typeof(Signaling))]

public class VolumeRegulator : MonoBehaviour
{
    private AudioSource _audioSource;
    private Signaling _signaling;
    private float _timeDelay;
    private float _countChangeVolume;
    private float _maxVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _signaling = GetComponent<Signaling>();
        _audioSource.volume = 0;
        _timeDelay = 1;
        _countChangeVolume = 0.1f;
        _maxVolume = 1;
    }

    public IEnumerator IncreaseVolume()
    {
        WaitForSeconds timeDelay = new WaitForSeconds(_timeDelay);

        while (_audioSource.volume < _maxVolume)
        {
            if (_signaling.GetStatusWork() == false)
            {
                break;
            }

            _audioSource.volume += _countChangeVolume;
            yield return timeDelay;
        }
    }

    public IEnumerator DecreaseVolume()
    {
        WaitForSeconds timeDelay = new WaitForSeconds(_timeDelay);

        while (_audioSource.volume > 0)
        {
            if (_signaling.GetStatusWork() == true)
            {
                break;
            }

            _audioSource.volume -= _countChangeVolume;
            yield return timeDelay;
        }
    }
}
