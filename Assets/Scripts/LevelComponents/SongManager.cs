using UnityEngine;

// Coordinates all the components (through store)
public class SongManager : MonoBehaviour
{
    // Starting the level
        // Give track to music player (thru store)
        // Give bpm to metronome (thru store)
        // Give level data to composer (thru store)
        // Emits event telling all components (thru store) that game is starting
    
    // Update
        // Listen to judge events (fail/succeed thru store) to keep score
        // Wait for event from music player (thru store) to stop the level
            // Or also through a low enough score
    
    // Stop the level
        // Emit end level event (through store)
        // Compute player's final score
}
