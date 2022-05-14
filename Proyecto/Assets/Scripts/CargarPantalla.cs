using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarPantalla : MonoBehaviour {
    public int si;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cargar(string NombrePantalla){
        if(si == 1)
        {
            int coin = PlayerPrefs.GetInt("con");
            coin++;
            if (coin == 11)
                coin = 0;
            PlayerPrefs.SetInt("con", coin);
            PlayerPrefs.SetInt("lock", 0);
        }
        SceneManager.LoadScene(NombrePantalla);
        PlayerPrefs.SetInt("pu", 0);
    }

    public void Cerrar()
    {
        Application.Quit();
    }
}
