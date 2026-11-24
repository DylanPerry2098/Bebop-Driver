using System;
using UnityEngine;

// Counts the beats
public class Metronome : MonoBehaviour
{
    public Store store;
    // Events
    // Central to Conducting.
    private float beatsPerMinute; // Beats per minute of song
    private float beatDurationMs; // Time duration of beat, calculated from BPM
    private float offset = 0.2f; // Offsets mp3 metadata to play on time. Positive values must me minused
    private float songPosition; // Keeps EVERYTHING in sync // Set from corresponding variable on Audio Object
    
    private int lastBeat = 0;
    private float nextBeatPosition;
    private int activeBeat = -1; // The current beat. Value is current beat if valid, -1 if otherwise
    private float margin = 300f; // Margin of error in milliseconds
    private float activeBeatStartPos;
    private float activeBeatEndPos;

    private void Awake()
    {
        Store.startMetronome += StartMetronome;
        Store.updateLevel += UpdateMetronome;
    }

    private void StartMetronome(int beatsPerMinute)
    {
        this.beatsPerMinute = beatsPerMinute;
        beatDurationMs = (60f / beatsPerMinute) * 1000f;
        nextBeatPosition = beatDurationMs;
        
        activeBeat = -1;
        activeBeatStartPos = nextBeatPosition - margin;
        activeBeatEndPos = nextBeatPosition + margin;
    }

    private void UpdateMetronome()
    {
        songPosition = store.GetSongPosition() + offset;
        
        if (songPosition >= nextBeatPosition)
        {
            lastBeat += 1;
            store.UpdateLastBeat(lastBeat);
            
            nextBeatPosition += beatDurationMs;
            activeBeatStartPos = nextBeatPosition - margin;
            activeBeatEndPos = nextBeatPosition + margin;
        }
        
        if (songPosition > activeBeatStartPos && songPosition < activeBeatEndPos)
        {
            if (activeBeat != -1)
            {
                return;
            }
            activeBeat = lastBeat;
            store.ValidActiveBeat(activeBeat);
        }
        else
        {
            if (activeBeat == -1)
            {
                return;
            }
            activeBeat = -1;
            store.InvalidActiveBeat();
        }
        // Debug.Log(activeBeat);
    }

    public void StopMetronome()
    {
        // Stop the level
        // Called when GameManager emits end level event (thru store)
        // Stops the count
    }
    

    
}
