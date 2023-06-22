using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _tankAudioSource;
    [SerializeField] private ParticleSystem _dustParticles;

    private void OnEnable()
    {
        // Subscribe methods in events
        GetComponent<FollowWP>().OnTankMoving += PlayEffects;
        GetComponent<FollowWP>().OnTankStopped += StopEffects;
    }

    private void OnDisable()
    {
        // Unsubscribe methods from events
        GetComponent<FollowWP>().OnTankMoving -= PlayEffects;
        GetComponent<FollowWP>().OnTankStopped -= StopEffects;
    }

    private void PlayEffects()
    {
        if (_tankAudioSource != null && _tankAudioSource.clip != null && !_tankAudioSource.isPlaying)
            _tankAudioSource.Play();

        if (_dustParticles != null && !_dustParticles.isPlaying)
            _dustParticles.Play();
    }

    private void StopEffects()
    {
        if (_tankAudioSource != null && _tankAudioSource.clip != null && _tankAudioSource.isPlaying)
            _tankAudioSource.Stop();

        if (_dustParticles != null && _dustParticles.isPlaying)
            _dustParticles.Stop();
    }
}