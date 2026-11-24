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
        Store.updateLevel += OnUpdateLevel;
        
        Store.pauseGame += OnPauseGame;
        Store.resumeGame += OnResumeGame;
    }

    private void StartMusicPlayer(AudioSource music)
    {
        _music = music;
        _music.Play();
       
    }

    private void OnUpdateLevel()
    {
        UpdateSongPosition();
    }

    private void UpdateSongPosition()
    {
        float songPosition = _music.time * 1000f;
        store.UpdateSongPosition(songPosition);

        // Ends the level when the music stops playing
        if (!_music.isPlaying)
        {
            EndMusic();
        }
    }

    // Stop the music
    // Called when GameManager emits end level event (thru store)
    private void EndMusic()
    {
        Debug.Log("Level has ended");
    }

    private void OnPauseGame()
    {
        _music.Pause();
    }

    private void OnResumeGame()
    {
        _music.Play();
    }
    
}
