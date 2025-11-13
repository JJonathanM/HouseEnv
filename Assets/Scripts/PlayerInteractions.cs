using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour {

    [SerializeField] List<GameObject> vidas;
    int cont;

    public void Start() 
    {
        cont = vidas.Count;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            cont--;
            if (cont < 0)
            {
                SceneManager.LoadScene("Menu");
            }
            vidas[cont].SetActive(false);
        }
    }

    public void Update() {
    
    }
    
}
