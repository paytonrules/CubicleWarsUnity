using System;
using UnityEngine;
using CubicleWarsLibrary;

// The "controller" because it takes input from the game system
public class UnitController : MonoBehaviour {
  protected Unit unit;
  protected StateMachine stateMachine;
  
	// 
  void Start() 
  {
    stateMachine = GameRouter.stateMachine;
  }

	// Bind is very simple
  public void Bind(Unit unit) 
  {
    this.unit = unit;
  }
	// This selects a unit.  The Cubicle Wars state machine takes
	// a game unit, not a unity object.
	void OnMouseDown() 
  	{
		stateMachine.Select(unit);
	}
}
