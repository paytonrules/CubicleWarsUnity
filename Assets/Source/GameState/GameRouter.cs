using UnityEngine;
using CubicleWarsLibrary;

public class GameRouter : MonoBehaviour {

  // Make a controller for this ?
  public static CubicleWarsStateMachine stateMachine;

  void Awake() {
		stateMachine = new CubicleWarsStateMachine(
			new HumanPlayer("Player1"),
			new HumanPlayer("Player2"));

   	 var view = gameObject.GetComponent<GameView>();
    view.Bind(stateMachine);
	}
}
