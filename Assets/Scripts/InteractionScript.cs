using System;
using UnityEngine;

public class interactionScript : MonoBehaviour
{
    [SerializeField] GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //transform.Translate(transform.position.x, transform.position.y + 2, transform.position.z);
            GameObject.Instantiate(obj, new Vector3(-2, 10, -1), Quaternion.identity);
        } 
        else 
        {
            Console.WriteLine("Es otro: " + other.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(false);
    }
}
