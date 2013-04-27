using UnityEngine;
using CubicleWarsLibrary;
using CubicleWarsLibrary.Effects;
using System;

// This view is responsibile for making the objects flicker.
public class UnitView : MonoBehaviour {
	// Data
  const float amplitude = 1.0f / 3.0f;
  const float frequency = 6.0f;
  const float offset = 0.9f;
  
	// Public - again so it can be set by the Unity editor
  public Color tint;
	
  protected Unit unit;
  protected bool StartWaiting { get; set; }
  protected SineWave wave;

  void Start() 
  {
    renderer.material.color = tint;
		// SineWave is an effect that is in the library. 
    wave = new SineWave(amplitude, frequency, offset);
  }
	
	// Bind sets up unit
  public void Bind(Unit unit)
  {
    this.unit = unit;
  
		// Bind also sets up for waiting events
    this.unit.Waiting += delegate() {
      StartWaiting = true;
    };

    this.unit.DoneWaiting += delegate() {
      StartWaiting = false;
    };
  }

  	void Update() 
	{
		// Each update checks if we are waiting, and if so
		// modulates the color based on the sin wave and the 
		// current time.
		if (StartWaiting) {
      		renderer.material.color = tint * wave.at(Time.time);
    	}
	}
}
