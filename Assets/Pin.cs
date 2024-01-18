using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pin : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public bool touched = false;

    void OnTriggerEnter( Collider coll)
    {
        if  (touched == false){
            ScoreManager.ScoreAjout();
            touched = true;
        }
    }
}