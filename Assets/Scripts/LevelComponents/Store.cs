using System;
using UnityEngine;

public class Store : MonoBehaviour
{
    // Events (definitely not finished)
    public static event Action updateLevel;
        // Metronome
    public static event Action validActiveBeat;
    public static event Action invalidActiveBeat;
    public static event Action<int> emitLastBeat;
    
        // Judge
    public static event Action success;
    public static event Action fail;

        // Input Handler
    public static event Action<int> updateSlidePosition;
        // Composer
        
        // MusicPlayer

        // SongManager
    public static event Action startLevel;
    public static event Action endLevel;
    
    
    // Variables
    private float input;
    private float songPosition;
    private float lastBeat;

    // Updater Functions that emit events
    
    // Song Manager
    public void StartLevel()
    {
        startLevel?.Invoke();
    }

    public void UpdateLevel()
    {
        updateLevel?.Invoke();
    }

    public void EndLevel()
    {
        endLevel?.Invoke();
    }
    
    // Music Player
    public void UpdateSongPosition()
    {
        // Get the current song position from the music player
        throw new System.NotImplementedException();
    }

    // Input Handler
    public void UpdateSlideInput(int input)
    {
        this.input = input;
        updateSlidePosition?.Invoke(input);
    }

    // Judge
    public void EmitFail()
    {
        throw new System.NotImplementedException();
    }

    public float EmitSuccess()
    {
        throw new System.NotImplementedException();
    }
    
}
