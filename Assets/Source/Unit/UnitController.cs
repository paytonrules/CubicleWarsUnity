using System;
using UnityEngine;
using CubicleWarsLibrary;

public class UnitController : MonoBehaviour {
  protected Unit unit;
  protected StateMachine stateMachine;

  void Start() 
  {
    stateMachine = GameRouter.stateMachine;
  }

  public void Bind(Unit unit) 
  {
    this.unit = unit;
  }

	void OnMouseDown() 
  {
		stateMachine.Select(unit);
	}
}
