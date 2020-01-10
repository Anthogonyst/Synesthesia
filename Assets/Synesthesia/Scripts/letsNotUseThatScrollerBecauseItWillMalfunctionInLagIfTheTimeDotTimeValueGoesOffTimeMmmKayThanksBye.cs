using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letsNotUseThatScrollerBecauseItWillMalfunctionInLagIfTheTimeDotTimeValueGoesOffTimeMmmKayThanksBye : MonoBehaviour {

	public Transform start, end;
	public float speed = 0.5f;
	
	private float fraction;
	private Vector3 begin, stop;
	
	// Use this for initialization
	void Start () {
		begin = start.position;
		stop = end.position;
	}
	
	void Update(){
		if (fraction < 1) {
			fraction += Time.deltaTime * speed;
			transform.position = Vector3.Lerp(begin, stop, fraction);
		}
		else {
			transform.position = Vector3.Lerp(begin, stop, 1);
			Destroy(this);
		}
	}

    public void thing()
    {
        
    }
}
