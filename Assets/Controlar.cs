using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlar : MonoBehaviour
{
    public string nombre;
    public static Controlar Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
