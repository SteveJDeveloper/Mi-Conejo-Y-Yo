using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PanCarga : MonoBehaviour {

    public GameObject zan1;
    public GameObject zan2;
    public GameObject zan3;
    public float tiempo_inicio = 0.0F;
    public float tiempo_final = 0.0F;
    public int cont;
    public string escena1;
    public string escena2;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("con", 0);
        PlayerPrefs.SetInt("lock", 0);
	}
	
	// Update is called once per frame
	void Update () {
        
        tiempo_inicio += Time.deltaTime;
        if (tiempo_inicio >= tiempo_final)
        {
            string filePath = Path.Combine(Application.persistentDataPath, "Termin");
            if (!File.Exists(filePath))
            {
                SceneManager.LoadScene(escena1);
            }
            else
            {
                SceneManager.LoadScene(escena2);
            }
        }
        else
        {
            if(cont <= 10)
            {
                zan1.GetComponent<Image>().enabled = true;
                zan2.GetComponent<Image>().enabled = false;
                zan3.GetComponent<Image>().enabled = true;
            }
            else
            {
                zan1.GetComponent<Image>().enabled = false;
                zan2.GetComponent<Image>().enabled = true;
                zan3.GetComponent<Image>().enabled = false;
            }
            if (cont == 20)
                cont = 0;
            else
                cont++;
        }
    }
}
