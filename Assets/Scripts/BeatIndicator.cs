using UnityEngine;

public class BeatIndicator : MonoBehaviour
{
    private Material _material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Store.validActiveBeatEvent += OnValidActiveBeat;
        Store.invalidActiveBeatEvent += OnInvalidActiveBeat;

        _material = GetComponent<Renderer>().material;
    }

    void OnValidActiveBeat()
    {
        _material.color = Color.green;
    }

    void OnInvalidActiveBeat()
    {
        _material.color = Color.white;
    }
}
