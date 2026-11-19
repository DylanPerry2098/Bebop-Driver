using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Variable for holding audio file with 
    public Store store;
    private AudioSource _music;

    private void Awake()
    {
        Store.startMusicPlayer += StartMusicPlayer;
        Store.updateLevel += UpdateSongPosition;
    }

    private void StartMusicPlayer(AudioSource music)
    {
        _music = music;
        _music.Play();
       
    }

    private void UpdateSongPosition()
    {
        float songPosition = _music.time * 1000f;
        store.UpdateSongPosition(songPosition);
    }
    
    
    // Stop the music
    // Called when GameManager emits end level event (thru store)
}
