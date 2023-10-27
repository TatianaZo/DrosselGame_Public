using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// текстовый контроллер
/// </summary>
public class ViewController : MonoBehaviour
{
    public GameObject popupGameOver, popupStartGame;
    public Text scoreMissed, scoreDone, endScoreMissed, endScoreDone;

    public void ChangePoint(int val)
    {
        scoreDone.text = val.ToString();
        endScoreDone.text = val.ToString();
    }

    public void ChangeMissedPoint(int val)
    {
        scoreMissed.text = val.ToString();
        endScoreMissed.text = val.ToString();
    }
    
    public void GameOver() //включает попап показа очков
    {
        popupGameOver.SetActive(true);
        scoreDone.gameObject.SetActive(false);
        scoreMissed.gameObject.SetActive(false);
    }

    public void OnPopupStartGame() // выключает попап очков и включает попап начального экрана
    {
        popupStartGame.SetActive(true);
        popupGameOver.SetActive(false);
    }
    public void OffPopupStartGame() // выключает попап начального экрана и загружается ига
    {
        popupStartGame.SetActive(false);
        scoreDone.gameObject.SetActive(true);
        scoreMissed.gameObject.SetActive(true);
        scoreDone.text = 0.ToString();
        scoreMissed.text = 0.ToString();
    }
}
