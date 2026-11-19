using System;
using UnityEngine;

// Counts the beats
public class Metronome : MonoBehaviour
{
    // Events
    // Central to Conducting.
    private float beatsPerMinute; // Beats per minute of song
    private float beatDurationMs; // Time duration of beat, calculated from BPM
    private float offset = 0.2f; // Offsets mp3 metadata to play on time. Positive values must me minused
    private float songPosition; // Keeps EVERYTHING in sync // Set from corresponding variable on Audio Object
    
    private int lastBeat;
    private float nextBeatPosition;
    private int activeBeat = -1; // The current beat. Value is current beat if valid, -1 if otherwise
    private float margin = 80f; // Margin of error in milliseconds
    private float activeBeatStartPos;
    private float activeBeatEndPos;
    
    
    public Metronome(float beatsPerMinute)
    {
        this.beatsPerMinute = beatsPerMinute;
        beatDurationMs = 60f / beatsPerMinute * 1000f;
        nextBeatPosition = beatDurationMs;
        
        activeBeat = -1;
        activeBeatStartPos = nextBeatPosition - margin;
        activeBeatEndPos = nextBeatPosition + margin;
    }

    public void UpdateMetronome()
    {
        // songPosition = Store.GetSongPosition();
        if (songPosition >= nextBeatPosition)
        {
            lastBeat += 1;
            // Emit the lastBeat value
        }

        nextBeatPosition += beatDurationMs;

        // Update activeBeat with margin (and positions)
        // Emit when activeBeat is valid
        // Emit when activeBeat is invalid (-1)
    }

    public void StopMetronome()
    {
        // Stop the level
        // Called when GameManager emits end level event (thru store)
        // Stops the count
    }
    

    
}
