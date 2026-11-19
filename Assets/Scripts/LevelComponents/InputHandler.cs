using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Store store;

    private void Awake()
    {
        Store.updateLevel += GetInput;
    }
    
    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            store.UpdateSlideInput(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            store.UpdateSlideInput(1);
        }
        else
        {
            store.UpdateSlideInput(0);
        }
    }
}
