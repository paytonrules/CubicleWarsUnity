using System;
using CubicleWarsLibrary;
using UnityEngine;
using System.Collections.Generic;

public class UnitRouter : MonoBehaviour, UnityObject
{
  public int initialHealth;
  public int InitialHealth { 
    get { return initialHealth; }
  }
  public String Name { get { return gameObject.name; }}
  public Vector3 labelOffset = Vector3.up;
  public GameObject labelPreFab;

  void Start() {
    var stateMachine = GameRouter.stateMachine;
    var unit = new StandardUnit(ConflictTable.resolver, this);

    var controller = gameObject.GetComponent<UnitController>();
    controller.Bind(unit);

    var healthLabel = Instantiate(labelPreFab, 
                                  transform.position, 
                                  transform.rotation) as GameObject;

    var labelScript = healthLabel.GetComponent<HealthLabel>();
    labelScript.Bind(unit);
    labelScript.target = gameObject.transform;
    labelScript.offset = labelOffset;

    Debug.Log("SHOES ON");
    var unitView = gameObject.GetComponent<UnitView>();
    unitView.Bind(unit);
    
    stateMachine.AddUnitToPlayer(gameObject.tag, unit);
  }
}
