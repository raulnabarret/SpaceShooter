using UnityEngine;
using System.Collections;
using System.Timers;

/* Mover se usa para especificar la velocidad de lo asteroides y la laser de la nave */
public class Mover : MonoBehaviour {

	public float speed; 

	void Start () {

		rigidbody.velocity = transform.forward * speed;

	}
}
