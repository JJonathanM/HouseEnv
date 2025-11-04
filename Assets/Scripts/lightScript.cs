using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class lightScript : MonoBehaviour
{
    [Header("Lights")]
    [SerializeField] Light[] lights;

    [Header("Input")]
    [SerializeField] InputActionReference interaction;  // F keyboard

    [Header("State")]
    [SerializeField] bool manageLigths = false;  // Initial state off

    bool player_near;

    void Start()
    {
        SetLights(manageLigths);
    }

    private void Update()
    {
        if (player_near && interaction.action.triggered)
        {
            manageLigths = !manageLigths;
            SetLights(manageLigths);
            Debug.Log("Interruptor: " + (manageLigths ? "ON" : "OFF"));
        }
    }

    void SetLights(bool state)
    {
        foreach (Light l in lights)
        {
            if (l != null)
            {
                l.enabled = state;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_near = true;
            Debug.Log("Press F to toggle ligths");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_near = false;
        }
    }
}