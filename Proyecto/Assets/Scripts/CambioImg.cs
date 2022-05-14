using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioImg : MonoBehaviour {

    public GameObject Imagen1;
    public GameObject Imagen2;
    public GameObject Imagen3;
    public GameObject Imagen4;
    public GameObject Imagen5;
    public GameObject Imagen6;
    public GameObject Imagen7;
    public GameObject Imagen8;
    public GameObject Imagen9;
    public GameObject Imagen10;
    public GameObject Imagen11;

    // Use this for initialization
    void Start () {
        Ocultar();
     }
	
	// Update is called once per frame
	void Update () {
        if(PlayerPrefs.GetInt("lock") == 0)
        {
            int coin = PlayerPrefs.GetInt("con");
            Ocultar();
            switch (coin)
            {
                case 0:
                    {
                        Imagen1.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 1:
                    {
                        Imagen2.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 2:
                    {
                        Imagen3.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 3:
                    {
                        Imagen4.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 4:
                    {
                        Imagen5.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 5:
                    {
                        Imagen6.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 6:
                    {
                        Imagen7.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 7:
                    {
                        Imagen8.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 8:
                    {
                        Imagen9.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 9:
                    {
                        Imagen10.GetComponent<Image>().enabled = true;
                        break;
                    }
                case 10:
                    {
                        Imagen11.GetComponent<Image>().enabled = true;
                        break;
                    }
            }
            PlayerPrefs.SetInt("lock", 1);
        }
        
	}

    void Ocultar()
    {
        Imagen1.GetComponent<Image>().enabled = false;
        Imagen2.GetComponent<Image>().enabled = false;
        Imagen3.GetComponent<Image>().enabled = false;
        Imagen4.GetComponent<Image>().enabled = false;
        Imagen5.GetComponent<Image>().enabled = false;
        Imagen6.GetComponent<Image>().enabled = false;
        Imagen7.GetComponent<Image>().enabled = false;
        Imagen8.GetComponent<Image>().enabled = false;
        Imagen9.GetComponent<Image>().enabled = false;
        Imagen10.GetComponent<Image>().enabled = false;
        Imagen11.GetComponent<Image>().enabled = false;
    }
}
