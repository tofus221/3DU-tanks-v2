using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip _roundStart;
    [SerializeField] private AudioClip _roundEnd;
    [SerializeField] private AudioClip _missionClear;
    [SerializeField] private AudioClip _music;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public IEnumerator PlayRoundStart()
    {
        _audio.Stop();
        _audio.PlayOneShot(_roundStart);
        yield return new WaitForSeconds(_roundStart.length);
        _audio.PlayOneShot(_music);
    }

    public float PlayRoundEnd()
    {
        _audio.Stop();
        _audio.PlayOneShot(_roundEnd);
        return _roundEnd.length;
    }
    
    public float PlayMissionClear()
    {
        _audio.Stop();
        _audio.PlayOneShot(_missionClear);
        return _missionClear.length;
    }
    
}
