using UnityEngine;
using CubicleWarsLibrary;
using CubicleWarsLibrary.Effects;
using System;

public class UnitView : MonoBehaviour {
  const float amplitude = 1.0f / 3.0f;
  const float frequency = 6.0f;
  const float offset = 0.9f;

  public Color tint;
  protected Unit unit;
  protected bool StartWaiting { get; set; }
  protected SineWave wave;

  void Start() 
  {
    renderer.material.color = tint;
    wave = new SineWave(amplitude, frequency, offset);
  }

  public void Bind(Unit unit)
  {
    this.unit = unit;
  
    this.unit.Waiting += delegate() {
      StartWaiting = true;
    };

    this.unit.DoneWaiting += delegate() {
      StartWaiting = false;
    };
  }

  void Update() {
    if (StartWaiting) {
      renderer.material.color = tint * wave.at(Time.time);
    }
	}
}
