using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Planes : MonoBehaviour {
	[SerializeField] Transform _a = null;
	[SerializeField] Transform _b = null;
	[SerializeField] Transform _c = null;
	
	[SerializeField] Transform _rOrigin = null;
	[SerializeField] Transform _rEnd = null;
	
	protected void Update() {
		Vector3 a = _a.position;
		Vector3 b = _b.position;
		Vector3 c = _c.position;
		Vector3 d = c + b - a;
		
		Vector3 rOrigin = _rOrigin.position;
		Vector3 rEnd = _rEnd.position;
		
		Plane plane = new Plane(a, b, c);
		
		Debug.DrawLine(a, b, Color.green);
		Debug.DrawLine(a, c, Color.green);
		Debug.DrawLine(c, d, Color.green);
		Debug.DrawLine(b, d, Color.green);
		
		Debug.DrawLine(rOrigin, rEnd, Color.yellow);
		
		Vector3 v = b - a;
		Vector3 s = c - a;
		Vector3 w = rEnd - rOrigin;
		
		Vector3 n = Vector3.Cross(v, s);
		
		float t = - Vector3.Dot(n, rOrigin - a) / Vector3.Dot(n, w);
		Vector3 intersection = rOrigin + w * t;
		
		DebugExtension.DebugPoint(intersection, Color.black);
		Debug.DrawLine(a, intersection, Color.green);
		Debug.DrawLine(b, intersection, Color.green);
		Debug.DrawLine(c, intersection, Color.green);
		Debug.DrawLine(d, intersection, Color.green);
		
		DebugExtension.DebugArrow(a, n - a, Color.white);
	}
}
