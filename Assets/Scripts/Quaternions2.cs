using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Quaternions2 : MonoBehaviour {
	[SerializeField] bool _showValues = true;
	[SerializeField] Transform _v1 = null;
	[SerializeField] Transform _v2 = null;
	[SerializeField] Transform _v3 = null;
	[SerializeField] Transform _v4 = null;
	[SerializeField] bool _reset = false;
	
	[SerializeField] float _angle = 10f;
	
	void ResetValues() {
		_reset = false;
		_v1.position = Vector3.zero;
		_v2.position = new Vector3(6, 0, 0);
		_v3.position = _v1.position;
		_v4.position = _v2.position;
		_angle = 0;
	}
	
	void Update() {
		if(_reset) ResetValues();
		
		Vector3 v1 = _v1.position;
		Vector3 v2 = _v2.position;
		Vector3 v3 = _v3.position;
		Vector3 v4 = _v4.position;
		
		DebugExtension.DebugArrow(v1, v2 - v1, Color.green);
		
		_v4.position = Quaternion.AngleAxis(_angle, Vector3.forward) * v2;
		v4 = _v4.position;
		
		DebugExtension.DebugArrow(v3, v4 - v3, Color.blue);
		
	    _showValues = false;
    }
}
