using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;
    public Text Record;
    private static int mayor = 0;
    public string maxim = "Máx: ";
    string jugad;
    //private static string cososs;

    void Start()
    {
        // maxim = "Máximo: " + mayor;
        Record.color = Color.white;
        Record.text = maxim + mayor;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Manager.GameOver();
    }
    private void Update()
    {
        if (Manager.m_Points > mayor)
        {
            Record.color = Color.green;
            mayor = Manager.m_Points;
            // maxim = "Mayor: " + mayor;
            if (Controlar.Instance != null)
            {
                jugad = Controlar.Instance.nombre;
            }
            Record.text = maxim + mayor + " por " + jugad;
        }
    }
}
