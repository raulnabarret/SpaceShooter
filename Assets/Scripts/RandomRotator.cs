using UnityEngine;
using System.Collections;

/* RandomRotator es para rotatar meteoros en direccion al azar */
public class RandomRotator : MonoBehaviour {

	public float tumble;

	void Start () {
		// Cuan rapido gira el meteorito
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble; 
	}

}
