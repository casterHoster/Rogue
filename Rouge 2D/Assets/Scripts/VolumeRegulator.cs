using System.Collections;
using UnityEngine;

public class VolumeRegulator : MonoBehaviour
{
    private AudioSource audioSource;
    private Signaling signaling;
    private float _timeDelay;
    private float _countChangeVolume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        signaling = GetComponent<Signaling>();
        audioSource.volume = 0;
        _timeDelay = 1;
        _countChangeVolume = 0.1f;
    }

    public IEnumerator IncreaseVolume()
    {
        WaitForSeconds timeDelay = new WaitForSeconds(_timeDelay);

        while (audioSource.volume < 1)
        {
            if (signaling.GetStatusWork() == false)
            {
                break;
            }

            audioSource.volume += _countChangeVolume;
            yield return timeDelay;
        }
    }

    public IEnumerator DecreaseVolume()
    {
        WaitForSeconds timeDelay = new WaitForSeconds(_timeDelay);

        while (audioSource.volume > 0)
        {
            if (signaling.GetStatusWork() == true)
            {
                break;
            }

            audioSource.volume -= _countChangeVolume;
            yield return timeDelay;
        }
    }
}
