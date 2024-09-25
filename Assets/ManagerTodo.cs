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
    public TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Awake()
    {
        
        boton = boton.gameObject.GetComponent<Button>();
        boton.onClick.AddListener(Cargar);
        
    }

    void Cargar()
    {

        // Debug.Log(boton.gameObject.name + " es " + nombre);
        if (Controlar.Instance.nombre != null)
        {
            SceneManager.LoadScene(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Controlar.Instance.nombre = texto.text;
        titular.text = Controlar.Instance.nombre;
    }
}
