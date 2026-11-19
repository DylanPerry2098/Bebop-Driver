using System;
using UnityEngine;

public class Store : MonoBehaviour
{
    // Events (definitely not finished)
        // Metronome
    public static event Action validActiveBeat;
    public static event Action invalidActiveBeat;
    public static event Action<int> emitLastBeat;
    
        // Judge
    public static event Action success;
    public static event Action fail;

        // Input Handler
    public static event Action<int> moveValue;
        // Composer
        
        // MusicPlayer

        // SongManager
    public static event Action startLevel;
    public static event Action endLevel;
    
        // UI
    
    
    // Variables
    private float songPosition;
    private float lastBeat;

    // Updater Functions that emit events
    public void SetSongPosition()
    {
        // Get the current song position from the music player
        throw new System.NotImplementedException();
    }

    public void UpdateSlideInput(int input)
    {
        moveValue?.Invoke(input);
    }

    public void EmitFail()
    {
        throw new System.NotImplementedException();
    }

    public float EmitSuccess()
    {
        throw new System.NotImplementedException();
    }
    
}
