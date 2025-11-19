using UnityEngine;
using UnityEngine.InputSystem;

public class doorScript : MonoBehaviour
{

    Animator animator;

    [Header("Input")]
    [SerializeField] InputActionReference interaction;

    [Header("State")]
    bool state = false;

    bool player_near;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_near && interaction.action.triggered)
        {
            if (!state)
            {
                animator.SetBool("isOpen", true);
                state = true;
            }
            else
            {
                animator.SetBool("isOpen", false);
                state = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_near = true;
            Debug.Log("Press F to open the door");
        }
        //animator.SetBool("isOpen", true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_near = false;
        }
        //animator.SetBool("isOpen", false);
    }

}
