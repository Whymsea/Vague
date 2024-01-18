using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public int Score;
  void Start () {
    Score = 0;
    SetCountText();
  }
  
  void Update() {
    Debug.Log("Score: " + Score);
  }
    public void ScoreAjout(){
        Score = Score+ 1;
        SetCountText();
    }
  
  void SetCountText()
  {
    ScoreText.text = "Score : " + Score.ToString();
    
    if(Score == 10)
    {
    
    }
  }
}
