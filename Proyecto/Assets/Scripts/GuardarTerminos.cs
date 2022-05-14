using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GuardarTerminos : MonoBehaviour {

    public GameObject toggle;
    public string escena;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (toggle.GetComponent<Toggle>().isOn)
        {
            string filePath = Path.Combine(Application.persistentDataPath, "Termin"); //Cambiar el nombre si se quiere testear en Luchin
            FileData GameData = FileData.Create(filePath);
            if (GameData.Save())
            {
                SceneManager.LoadScene(escena);
            }
        }
    }
}
