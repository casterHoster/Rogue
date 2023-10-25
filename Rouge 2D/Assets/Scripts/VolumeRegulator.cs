using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Signaling))]

public class VolumeRegulator : MonoBehaviour
{
    [SerializeField] private float _speedChange;

    private Signaling _signaling;
<<<<<<< HEAD
    private AudioSource _audioSource;
=======
    private float _timeDelay;
    private float _countChangeVolume;
    private float _maxVolume;
>>>>>>> 204880f63e5e622ad66a7906c97c569c8e2e496b

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
<<<<<<< HEAD
        _signaling = GetComponent<Signaling>();
=======
        _timeDelay = 1;
        _countChangeVolume = 0.1f;
        _maxVolume = 1;
>>>>>>> 204880f63e5e622ad66a7906c97c569c8e2e496b
    }

    public IEnumerator ChangeVolume(float targeVolume)
    {
        bool isWork = _signaling.GetStatusWork();

<<<<<<< HEAD
        while (isWork == _signaling.GetStatusWork())
=======
        while (_audioSource.volume < _maxVolume)
>>>>>>> 204880f63e5e622ad66a7906c97c569c8e2e496b
        {
            _audioSource.volume = Mathf.MoveTowards( _audioSource.volume, targeVolume,  _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}
