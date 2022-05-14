using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Regresar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                int coin = PlayerPrefs.GetInt("con");
                coin++;
                if (coin == 11)
                    coin = 0;
                PlayerPrefs.SetInt("con", coin);
                PlayerPrefs.SetInt("pu", 0);
                PlayerPrefs.SetInt("lock", 0);
                SceneManager.LoadScene("P_MenuPrin");
            }
        }
    }
    
}
