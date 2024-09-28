using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;
    public Text Record;
    private static int mayor;
    public string maxim = "Máx: ";
    string jugad;
    private static Dictionary<string, int> puntajes = new Dictionary<string, int>();
    //private static string cososs;

    void Start()
    {
        // maxim = "Máximo: " + mayor;
        Record.color = Color.white;
        LoadNum();
        
        Record.text = maxim + jugad + " hizo " + mayor;
    }
    [System.Serializable]
    class SaveData
    {
        public int numero;
        public string name;
    }

    public void SaveNum()
    {
        SaveData data = new SaveData();
        data.numero = mayor;
        data.name = jugad; 

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadNum()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            mayor = data.numero;
            jugad = data.name;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        puntajes.Add(jugad, mayor);
        foreach (KeyValuePair<string, int> entry in puntajes)
        {
            UnityEngine.Debug.Log("Clave: " + entry.Key + ", Valor: " + entry.Value);
        }
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
            
            SaveNum();
        }
    }
}
