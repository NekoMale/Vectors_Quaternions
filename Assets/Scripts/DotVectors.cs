using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DotVectors : MonoBehaviour {
	[SerializeField] Transform _startV1 = null;
	[SerializeField] Transform _startV2 = null;
	
	[SerializeField] Transform _endV1 = null;
	[SerializeField] Transform _endV2 = null;
	
	void Update() {
		DebugExtension.DebugArrow(_startV1.position, _endV1.position - _startV1.position, Color.yellow);
		DebugExtension.DebugArrow(_startV2.position, _endV2.position - _startV2.position, Color.blue);
		
		Vector3 v1 = _endV1.position - _startV1.position;
		Vector3 v2 = _endV2.position - _startV2.position;
		
		
		DebugExtension.DebugArrow(_startV1.position, v2, Color.cyan);
		DebugExtension.DebugArrow(_startV1.position, v1.normalized * Vector3.Dot(v2.normalized, v1.normalized) * v2.magnitude, Color.magenta);
    }
}
