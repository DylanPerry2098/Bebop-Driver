using System;
using UnityEngine;

public class Store : MonoBehaviour
{
    // Events
    // public event Action emitBeat;
    
    // Variables
    
    // Singleton declaration (please please please find another way to do this)
    public static Store instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Functions (accessed via events)
    public float GetSongPosition()
    {
        throw new System.NotImplementedException();
    }
}
