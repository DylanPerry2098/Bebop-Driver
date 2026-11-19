using System;
using UnityEngine;

public class Store : MonoBehaviour
{
    // Events (definitely not finished)

    public static event Action startLevel;
    public static event Action updateLevel;
    public static event Action endLevel;
    
        // SongManager
    public static event Action<int> startMetronome;
    public static event Action startComposer;
    
        // MusicPlayer
    public static event Action<AudioSource> startMusicPlayer;
    public static event Action musicEnded;

    // Metronome
    public static event Action validActiveBeatEvent;
    public static event Action invalidActiveBeatEvent;
    public static event Action<int> emitLastBeatEvent;
    
        // Input Handler
    public static event Action<int> slideInputEvent;
        // Composer
        
        // Judge
        public static event Action successEvent;
        public static event Action failEvent;
        
    
    // Variables
    private int input;
    private float songPosition;
    
    private int lastBeat;
    private int activeBeat;

    // Updater Functions that emit events
    
    // Song Manager
    public void StartLevel(AudioSource music, int beatsPerMinute)
    {
        startMusicPlayer?.Invoke(music);
        startMetronome?.Invoke(beatsPerMinute);
        // startComposer?.Invoke();
        
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
    public void UpdateSongPosition(float songPosition)
    {
        this.songPosition = songPosition;
    }

    public float GetSongPosition()
    {
        return songPosition;
    }

    public void MusicEnded()
    {
        
    }
    
    // Metronome
    public void UpdateLastBeat(int lastBeat)
    {
        this.lastBeat = lastBeat;
    }

    public void ValidActiveBeat(int activeBeat)
    {
        this.activeBeat = activeBeat;
    }

    public void InvalidActiveBeat()
    {
        activeBeat = -1;
    }

    // Input Handler
    public void SlideInput(int input)
    {
        this.input = input;
        slideInputEvent?.Invoke(input);
    }
    
}
