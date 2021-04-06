using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Quaternions : MonoBehaviour {
	[SerializeField] bool _showValues = true;
	[SerializeField] Transform _object = null;
	[SerializeField] Transform _object2 = null;
	[SerializeField] Transform _object3 = null;
	[SerializeField] Transform _object4 = null;
	[SerializeField] bool _basic = false;
	[SerializeField] bool _advanced = false;
	[SerializeField] bool _expert = true;
	
	[SerializeField] float _angle = 10f;
	
	void Update() {
		float angle; Vector3 axis;
		if(_basic) {
			_object.rotation.ToAngleAxis(out angle, out axis);
		    DebugExtension.DebugArrow(_object.position, axis, Color.yellow);
		    if(_showValues) Debug.Log($"Object rotation angle: {angle}");
		    
	    	float angle2; Vector3 axis2;
	    	_object2.rotation = Quaternion.identity;
	    	_object2.rotation.ToAngleAxis(out angle2, out axis2);
		    DebugExtension.DebugArrow(_object2.position, axis2, Color.yellow);
		    if(_showValues) Debug.Log($"Object2 rotation angle: {angle2}");
		    
		    //_object2.rotation = _object.rotation;
		    _object2.rotation = Quaternion.identity * _object.rotation;
	    	_object2.rotation.ToAngleAxis(out angle2, out axis2);
		    DebugExtension.DebugArrow(_object2.position, axis2, Color.yellow);
		    
		    _object2.rotation = Quaternion.Inverse(_object2.rotation);
	    	_object2.rotation.ToAngleAxis(out angle2, out axis2);
		    DebugExtension.DebugArrow(_object2.position, axis2, Color.yellow);
		    
		    if(_showValues) Debug.Log(Quaternion.Angle(_object2.rotation, _object.rotation));
		    if(_showValues) Debug.Log(Quaternion.Angle(_object.rotation, _object2.rotation));
		}
		else if(_advanced) {
			if(!Application.isPlaying) return;
			
			
			axis = _object.position - Vector3.zero;
			Vector3 distFromAxis = _object2.position - Vector3.zero;
			
			_object4.position = _object.position + distFromAxis;
			
			DebugExtension.DebugArrow(Vector3.zero - axis * 5, Vector3.zero + axis * 5, Color.yellow);
			Debug.DrawLine(_object2.position - ((_object2.position - _object4.position) * 5), _object2.position + ((_object2.position - _object4.position) * 5), Color.white);
			
			
			_object3.position -= distFromAxis;
			_object3.position = Quaternion.AngleAxis(_angle + Time.deltaTime, axis) * _object3.position;
			_object3.position += distFromAxis;
			
			_object3.rotation *= Quaternion.AngleAxis(_angle + Time.deltaTime, axis);
		}
		else if(_expert) {
			Vector3 forw = _object2.position + Vector3.forward;
			_object2.rotation = Quaternion.FromToRotation(Vector3.forward, _object4.position - _object2.position);
			DebugExtension.DebugArrow(Vector3.forward, _object4.position, Color.white);
		}
		
		
	    _showValues = false;
    }
}
