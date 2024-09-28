using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerTodo : MonoBehaviour
{
    public Button boton;
    public TextMeshProUGUI titular;
    public TMP_InputField texto;

    // Start is called before the first frame update
    void Start()
    {
        
        boton = boton.gameObject.GetComponent<Button>();
        boton.onClick.AddListener(Cargar);
        
    }

    void Cargar()
    {

        if (texto.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Controlar.Instance.nombre = texto.text;
        titular.text = "Tu nombre: " + Controlar.Instance.nombre;

    }
}
