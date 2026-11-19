using System;
using UnityEngine;

// Coordinates all the components (through store)
public class SongManager : MonoBehaviour
{
    public Store store;
    public int beatsPerMinute;
    // Variable for audio track
    // Variable for level data
    

    private void Start()
    {
        store.StartLevel();
        // Emits event telling all components (thru store) that game is starting
        // Give track to music player (thru store)
        // Give bpm to metronome (thru store)
        // Give level data to composer (thru store)
        
    }

    private void Update()
    {
        // Update
        store.UpdateLevel();
        // Listen to judge events (fail/succeed thru store) to keep score
        // Wait for event from music player (thru store) to stop the level
        // Or also through a low enough score
    }

    private void EndLevel()
    {
        // Stop the level
        // Emit end level event (through store)
        // Compute player's final score
    }

    
    
}
