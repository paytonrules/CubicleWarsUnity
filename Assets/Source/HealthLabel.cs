using UnityEngine;
using CubicleWarsLibrary;
using System.Linq;

[RequireComponent (typeof (GUIText))]
public class HealthLabel : MonoBehaviour {
  public Transform target { get; set; }
  public Vector3 offset { get; set; }
  protected Unit unit { get; set; }
  
  public void Bind(Unit unit)
  {
    this.target = target;
    this.unit = unit;
	unit.Dead += () => DestroyObject(gameObject);
  }

	// We use update to poll the update for the health.
  void Update()
  {
    transform.position = Camera.main.WorldToViewportPoint(target.position + offset);
    gameObject.guiText.text = unit.Health.ToString();
  }
}
