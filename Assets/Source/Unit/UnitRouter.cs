using System;
using CubicleWarsLibrary;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// UnitRouter begins the processing for the CubicleWarsUnit. 
/// It creates the unit, and binds it to it's controller and views.
/// It adds the unit to the player through the state machine.
/// </summary>

public class UnitRouter : MonoBehaviour, UnityObject
{
  // This data is assigned by Unity, so it is public
  public int initialHealth;
  public Vector3 labelOffset = Vector3.up;
  public GameObject labelPreFab;
	
  // These getters are specified by the UnityObject interface
  public int InitialHealth { 
    get { return initialHealth; }
  }
  public String Name { get { return gameObject.name; }}

  
	/// <summary>
	/// Start this instance.
	/// </summary>
  void Start() {
    var stateMachine = GameRouter.stateMachine;
		
	// Create the standard Unit.  That object has all the game behavior.
    var unit = new StandardUnit(ConflictTable.resolver, this);
		
	// 'Bind' the controller.
    var controller = gameObject.GetComponent<UnitController>();
    controller.Bind(unit);
		
	// Instantiate a prefab for the health label
    var healthLabel = Instantiate(labelPreFab, 
                                  transform.position, 
                                  transform.rotation) as GameObject;

	// Bind it to the health label script
    var labelScript = healthLabel.GetComponent<HealthLabel>();
    labelScript.Bind(unit);
    labelScript.target = gameObject.transform;
    labelScript.offset = labelOffset;
		
	// Bind to the unit view.
	// So two views and one controller
    var unitView = gameObject.GetComponent<UnitView>();
    unitView.Bind(unit);
    
	// Assign the unit to it's player
    stateMachine.AddUnitToPlayer(gameObject.tag, unit);
  }
	
	// THE ROUTER DOES NOTHING ELSE
}
