using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int points;
    public Text pointsText;
    public Text LevelComplete;

	void Update () {
        //Показує рахунок
        pointsText.text = ("Score: " + points);
        //якщо рахунок >= 10, то перший рівень завершено
        if (points >= 10) {
            LevelComplete.text = ("Level 1 Completed" );
            //Application.LoadLevel(2);
        }
    }
}
