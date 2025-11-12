using UnityEngine;
using UnityEngine.SceneManagement;

public class init : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene("House");
    }
    public void Opciones()
    {
        SceneManager.LoadScene("House");
    }
    public void Salir()
    {
        Application.Quit();
        /*if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }*/
    }

}
