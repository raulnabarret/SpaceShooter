using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;

}

public class PlayerControler : MonoBehaviour {

	public float speed = 5;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float nextFire;
	public float fireRate;



	void Update () 
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
		}
	}
	/* Metodo FixedUpdate ejecuta el codigo una vez por cada movimiento fisico */
	void FixedUpdate ()
	{
		/* Input.GetAxis('NombreDelEje') retonar el valor en que el se encuentra el objeto player en el respectivo eje */
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		/* 
		 * Creando Vector3 movement
		 * x -> moveHorizontal*speed : Referencia de cuanto se move el objeto player en el eje x
		 * y -> 0.0f
		 * z -> moveVertical*speed : Referencia de cuanto se move el objeto player en el eje x
		 */
		Vector3 movement = new Vector3 (moveHorizontal*speed, 0.0f, moveVertical*speed);

		/* Aisgnamos velicidad al objeto player al agregarle el Vector3 movement */
		rigidbody.velocity = movement;

		/* 
		 * Se establece cuan lejos puede ir el objeto Player
		 * x -> El valor de Player.x puede estar entre boundary.xMin y boundaryx.xMax
		 * z -> El valor de Player.z puede estar entre boundary.zMin y boundaryx.zMax
		 */
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
			);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
