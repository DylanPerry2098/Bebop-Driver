using System;
using UnityEngine;

// Counts the beats
public class Metronome : MonoBehaviour
{
    // Central to Conducting.
    public float bpm; // Beats per minute of song
    public float beatDurationMs; // Time duration of beat, calculated from BPM
    public float offset = 0.2f; // Offsets mp3 metadata to play on time. Positive values must me minused
    public float songPosition; // Keeps EVERYTHING in sync // Set from corresponding variable on Audio Object
    
    public int lastBeat;
    public float nextBeatPosition;
    public int activeBeat = -1; // The current beat. Value is current beat if valid, -1 if otherwise
    private float margin = 80f; // Margin of error in milliseconds
    public float activeBeatStartPos;
    public float activeBeatEndPos;
    
    
    public Metronome(float bpm)
    {
        this.bpm = bpm;
        beatDurationMs = 60f / bpm * 1000f;
        nextBeatPosition = beatDurationMs;
        
        activeBeat = -1;
        activeBeatStartPos = nextBeatPosition - margin;
        activeBeatEndPos = nextBeatPosition + margin;
    }
    
    private void UpdateConductor()
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
        
        // Stop the level
            // Called when GameManager emits end level event (thru store)
            // Stops the count

    }
}
