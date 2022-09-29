using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _music;

    [SerializeField]
    private AudioSource _sound;

    [SerializeField]
    private List<AudioClip> _musicAudioClips;

    [SerializeField]
    private List<AudioClip> _soundAudioClips;

    [SerializeField]
    private PlayerUI _ui;

    public void PlayRandomMusic() {
        if (_ui.isMusic)
        {

            _music.clip = _musicAudioClips[Random.Range(1, _musicAudioClips.Count)];
            _music.Play();
        }
        else
            _music.Stop();
    }

    public void PlayMenuMusic() {
        if (_ui.isMusic)
        {

            _music.clip = _musicAudioClips[0];
            _music.Play();
        }
        else
            _music.Stop();
    }

    public void CreateUnitSound() {     _PlaySound(0); }
    public void DestroyUnitSound() {    _PlaySound(1); }
    public void BreakerDestroySound() { _PlaySound(2); }
    public void WinSound() {            _PlaySound(3); }
    public void LoseSound() {           _PlaySound(4); }

    private void _PlaySound(int _soundNumber) {
        if (_ui.isSound)
        {

            _sound.clip = _soundAudioClips[_soundNumber];
            _sound.Play();
        }
    }
    

}
