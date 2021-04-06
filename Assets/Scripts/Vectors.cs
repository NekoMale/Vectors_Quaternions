using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Vectors : MonoBehaviour {
	[SerializeField] bool _showValue = true;
	[SerializeField] Vector3 _v1 = new Vector3(3f, 0f, 5f);
	[SerializeField] Vector3 _v2 = new Vector3(-2f, 0f, 2f);
	[SerializeField] Vector3 _v3 = new Vector3(5f, 0f, 3f);
	[SerializeField] Vector3 _v4 = new Vector3(3f, 0f, 0f);
	
	[SerializeField] bool _basics = false;
	[SerializeField] bool _dot = true;
	[SerializeField] bool _cross = true;
	
	protected void Update() {
		DebugExtension.DebugArrow(Vector3.zero, _v1, Color.yellow);
		DebugExtension.DebugArrow(Vector3.zero, _v2, Color.blue);
		if(_basics) {
			float v1Magnitude = _v1.magnitude;
			
			if(_showValue) Debug.Log($"v1 magnitude/length {v1Magnitude}({Vector3.Distance(Vector3.zero, _v1)})");
			
			Vector3 v1N = new Vector3(_v1.x / v1Magnitude, _v1.y / v1Magnitude, _v1.z / v1Magnitude);
			DebugExtension.DebugArrow(Vector3.zero, v1N, Color.red);
			
			Vector3 v1M = (_v1 - Vector3.zero) * 0.5f;
			DebugExtension.DebugPoint(v1M, Color.blue);
			
			DebugExtension.DebugArrow(Vector3.zero, _v3, Color.cyan);
			DebugExtension.DebugArrow(Vector3.zero, _v4, Color.green);
			
			Debug.DrawLine(_v1, _v2, Color.black);
			Debug.DrawLine(_v1, _v3, Color.black);
			Debug.DrawLine(_v3, _v4, Color.black);
			Debug.DrawLine(_v2, _v4, Color.black);
			
			Vector3 CDM = (_v1 + _v2 + _v3 + _v4) * 0.25f;
			
			if(_showValue) Debug.Log($"Mass Center: {CDM}");
			DebugExtension.DebugPoint(CDM, Color.black);
			
			DebugExtension.DebugArrow(_v1, _v2, Color.blue);
			DebugExtension.DebugArrow(Vector3.zero, _v1 + _v2, Color.magenta);
			
			DebugExtension.DebugArrow(_v2, _v1, Color.yellow);
			/* Same as _v1 + _v2 */
			//DebugExtension.DebugArrow(Vector3.zero, _v2 + _v1, Color.white);
		}
		
		if(_dot) {
			float dot = _v1.x * _v2.x + _v1.y * _v2.y + _v1.z * _v2.z;
			if(_showValue) Debug.Log($"Dot: {dot}({Vector3.Dot(_v1, _v2)})");
			
			float alpha = Mathf.Acos(dot / (_v1.magnitude * _v2.magnitude));
			if(_showValue) Debug.Log($"alpha: {alpha  * Mathf.Rad2Deg}");
			
			float dot2 = _v1.magnitude * _v2.magnitude * Mathf.Cos(alpha);
			if(_showValue) Debug.Log($"Dot: {dot2}");
			
			float v2onv1 = _v2.magnitude * Mathf.Cos(alpha);
			Vector3 v2onv1V = v2onv1 * _v1.normalized;
			if(_showValue) {
				Debug.Log($"v2 on v1: {v2onv1}");
			}
			DebugExtension.DebugArrow(Vector3.zero, v2onv1V, Color.blue);
		}
		
		if(_cross) {
			Vector3 cross12 = Vector3.Cross(_v1, _v2);
			Vector3 cross21 = Vector3.Cross(_v2, _v1);
			
			DebugExtension.DebugArrow(Vector3.zero, cross12, Color.red);
			DebugExtension.DebugArrow(Vector3.zero, cross21, Color.cyan);
			
			if(_showValue) {
				float alpha12 = cross12.magnitude / (_v1.magnitude * _v2.magnitude);
				float sinAlpha12 = Mathf.Sin(alpha12);
				Debug.Log($"Sin({alpha12 * Mathf.Rad2Deg}) = {sinAlpha12}");
				float cross12m = _v1.magnitude * _v2.magnitude * sinAlpha12;
				Debug.Log($"Cross12 magnitude: {cross12m} ({cross12.magnitude})");
				
				float alpha21 = cross21.magnitude / (_v1.magnitude * _v2.magnitude);
				float sinAlpha21 = Mathf.Sin(alpha21);
				Debug.Log($"Sin({alpha21 * Mathf.Rad2Deg}) = {sinAlpha21}");
				float cross21m = _v1.magnitude * _v2.magnitude * sinAlpha21;
				Debug.Log($"Cross21 magnitude: {cross21m} ({cross21.magnitude})");
			}
		}
		
		if(_showValue) _showValue = false;
	}
}
