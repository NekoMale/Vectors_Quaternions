using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Lines : MonoBehaviour {
	[SerializeField] bool _showValue = true;
	[SerializeField] Transform _a = null;
	[SerializeField] Transform _aPerp = null;
	
	[SerializeField] Transform _bOrigin = null;
	[SerializeField] Transform _bEnd = null;
	[SerializeField] Transform _cOrigin = null;
	[SerializeField] Transform _cEnd = null;


    void Update() {
	    DebugExtension.DebugPoint(_a.position, Color.blue);
	    DebugExtension.DebugArrow(Vector3.zero, _a.position, Color.blue);
	    
	    _aPerp.position = new Vector3(-_a.position.z, 0, _a.position.x);
	    DebugExtension.DebugPoint(_aPerp.position, Color.white);
	    DebugExtension.DebugArrow(Vector3.zero, _aPerp.position, Color.white);
	    
	    if(_showValue) Debug.Log($"Dot(A, APerp): {Vector3.Dot(_a.position, _aPerp.position)}");
	    
	    Vector3 bOrigin = _bOrigin.position;
	    Vector3 bEnd = _bEnd.position;
	    Vector3 cOrigin = _cOrigin.position;
	    Vector3 cEnd = _cEnd.position;
	    
	    DebugExtension.DebugArrow(bOrigin, bEnd - bOrigin, Color.black);
	    DebugExtension.DebugArrow(cOrigin, cEnd - cOrigin, Color.yellow);
	    
	    Vector3 dOrigin = bOrigin;
	    Vector3 dEnd = cOrigin;
	    
	    DebugExtension.DebugArrow(dOrigin, dEnd - dOrigin, Color.cyan);
	    
	    Vector3 v = bEnd - bOrigin;
	    Vector3 u = cEnd - cOrigin;
	    
	    Vector3 uPerp = new Vector3(- u.z, 0, u.x);
	    Vector3 vPerp = new Vector3(- v.z, 0, v.x);
	    
	    float t = Vector3.Dot(uPerp, dEnd - dOrigin) / Vector3.Dot(uPerp, v);
	    float s = - Vector3.Dot(vPerp, dEnd - dOrigin) / Vector3.Dot(vPerp, u);
	    if(0 <= t && t <= 1 && 0 <= s && s <= 1) {
		    Vector3 intersection = bOrigin + v * t;
		    DebugExtension.DebugPoint(intersection, Color.magenta);
	    }
	    
	    _showValue = false;
    }
}
