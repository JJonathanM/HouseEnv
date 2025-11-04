using UnityEngine;

public class moveScripts : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    CharacterController characterC;
    [SerializeField] GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterC = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            Vector3 front = player.transform.forward * 1;
            Vector3 move = front * speed * Time.deltaTime;
            characterC.Move(move);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 front = player.transform.right * -1;
            Vector3 move = front * speed * Time.deltaTime;
            characterC.Move(move);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 front = player.transform.forward * -1;
            Vector3 move = front * speed * Time.deltaTime;
            characterC.Move(move);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 front = player.transform.right * 1;
            Vector3 move = front * speed * Time.deltaTime;
            characterC.Move(move);
        }
    }
}
