using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Triangles : MonoBehaviour {
	[SerializeField] bool _calculate = true;
	[SerializeField] Vector3 _vertexA = new Vector3(0f, 0f, 0f);
	[SerializeField] Vector3 _vertexB = new Vector3(3f, 0f, 0f);
	[SerializeField] Vector3 _vertexC = new Vector3(0f, 0f, 4f);
	
    void Update() {
	    Debug.DrawLine(_vertexA, _vertexB, Color.green);
	    Debug.DrawLine(_vertexA, _vertexC, Color.yellow);
	    Debug.DrawLine(_vertexB, _vertexC, Color.red);
	    if(_calculate) {
		    float a = (_vertexA - _vertexB).magnitude;
		    float b = (_vertexA - _vertexC).magnitude;
		    float c = (_vertexB - _vertexC).magnitude;
		    Debug.Log($"a: {a} b: {b} c: {c} ");
		    
		    
		    float alphaS = Mathf.Asin(a * Mathf.Sin(Mathf.PI * 0.5f) / c) * Mathf.Rad2Deg;
		    float betaS = Mathf.Asin(b * Mathf.Sin(Mathf.PI * 0.5f) / c) * Mathf.Rad2Deg;
		    
		    float alphaC = Mathf.Acos((b * b + c * c - a * a) / (2 * b * c)) * Mathf.Rad2Deg;
		    float betaC = Mathf.Acos((a * a + c * c - b * b) / (2 * a * c)) * Mathf.Rad2Deg;
		    
		    Debug.Log($"Sin: alpha {alphaS} beta {betaS}");
		    Debug.Log($"Cos: alpha {alphaC} beta {betaC}");
		    
		    Debug.Log($"Triangle angles sum: {alphaS + betaS + 90} | {alphaC + betaC + 90}");
		    
		    _calculate = false;
	    }
    }
}
