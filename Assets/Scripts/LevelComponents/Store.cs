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

    public static event Action<int> changeLaneEvent;
    // Composer
    
    // Judge
    public static event Action successEvent;
    public static event Action failEvent;
    
    // Other
    public static event Action pauseGame;
    public static event Action resumeGame;
    
    
    // Variables
    private int input = 0;
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
        validActiveBeatEvent?.Invoke();
    }

    public void InvalidActiveBeat()
    {
        activeBeat = -1;
        invalidActiveBeatEvent?.Invoke();
    }

    public int GetActiveBeat()
    {
        return activeBeat;
    }

    // Input Handler
    public void SlideInput(int input)
    {
        this.input = input;
        slideInputEvent?.Invoke(input);
    }
    
    // Judge
    public void EmitFail()
    {
        // failEvent?.Invoke();
    }

    public void EmitSuccess()
    {
        changeLaneEvent?.Invoke(input);
        successEvent?.Invoke();
    }
    
    // Other

    public void PauseGame()
    {
        pauseGame?.Invoke();
    }

    public void ResumeGame()
    {
        resumeGame?.Invoke();
    }
    
}
