using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    // NEED TO ADD INPUT BUFFERING TO THIS GAME
    public Store store;

    private void Awake()
    {
        Store.updateLevel += OnUpdateLevel;
    }
    
    private void OnUpdateLevel() 
    {
        GetInput();
    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            store.SlideInput(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            store.SlideInput(1);
        }
    }
}
