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
    public static event Action moveLeft;
    public static event Action moveRight;
        // Composer
        
        // MusicPlayer

        // SongManager
    public static event Action startLevel;
    public static event Action endLevel;
    
        // UI
    
    
    // Variables
    public float songPosition;
    public float lastBeat;

    // Updater Functions that emit events
    public float SetSongPosition()
    {
        // Get the current song position from the music player
        throw new System.NotImplementedException();
    }
    
}
