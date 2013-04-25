using UnityEngine;
using CubicleWarsLibrary;
using System.Collections.Generic;

public class ConflictTable : MonoBehaviour {

  // No reason for this to be public
  public static ConflictResolver resolver;

	protected Dictionary<string, Dictionary<string, int>> conflictTable;

  void Awake() {
    conflictTable = new Dictionary<string, Dictionary<string, int>>();

		conflictTable["Hacker"] = new Dictionary<string, int> { { "Sales", 1 } };
		conflictTable["Sales"] = new Dictionary<string, int> { { "Drone", 1 } };
		conflictTable["Drone"] = new Dictionary<string, int> { { "Hacker", 1 } };

		resolver = new RockPaperScissorsConflictResolver(conflictTable);
  }
}
