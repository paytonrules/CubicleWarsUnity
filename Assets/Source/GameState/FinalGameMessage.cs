using UnityEngine;
using System.Collections;

public class FinalGameMessage : MonoBehaviour {
  Transform newGame;

  void Start()
  {
    newGame = transform.Find("New Game");
    newGame.guiText.enabled = false;
  }

  void ShowWinner(string message) {
    guiText.text = message;
    guiText.enabled = true;
    newGame.guiText.enabled = true;
  }
}
