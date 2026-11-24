using System;
using UnityEngine;

// Determines which inputs are valid
public class Judge : MonoBehaviour
{
    public Store store;

    private void Awake()
    {
        Store.slideInputEvent += OnSlideInputEvent;
    }

    private void OnSlideInputEvent(int input)
    {
        VerifyInput(input);
    }
    
    private void VerifyInput(int input)
    {
        if (store.GetActiveBeat() == -1)
        {
            store.EmitFail();
        }
        else
        {
            store.EmitSuccess();
        }
    }

    private void OnEndLevel()
    {
        
    }

    // Waits for next input
    // Checks if the beat is active
    // If beat is not active -> fail
    // If beat is active -> succeed

    // IGNORE LOGIC DOWN BELOW

    // Asks composer (in store) for next input
    // One button, one beat position

    // Wait for event from player input (in store) // Emits two events: fail or succeed
    // Compare button press to required press
    // If no match -> fail
    // If match, ask metronome (in store) for active beat
    // If active beat is closed (-1) -> fail
    // If active beat is open but different from composer beat -> fail
    // If active beat window closes on the recorded beat -> fail
    // Final: Same button on same beat -->> succeed
    // Go back to ask composer (in store) for next input

    // Stop the level
    // Called when SongManager emits end level signal
    // Stops judging player input and beat

}
