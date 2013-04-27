using System;
using UnityEngine;
using CubicleWarsLibrary;

public class GameView : MonoBehaviour {

 	public GUIText winMessage;

  	public void Bind(StateMachine machine) 
	{
		machine.GameOver += delegate(string winner) {
      		winMessage.SendMessage("ShowWinner", String.Format("{0} wins!", winner));
		};
  	}
}
 
