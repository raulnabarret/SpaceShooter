using UnityEngine;
using System.Collections;

/* ScrollingBg se usa para mover el background del juego y similar movimiento por parte  de la nave */
public class ScrollingBg : MonoBehaviour {

	/* Adding speed field into Unity */
	#region Fields
	public float Speed;
	#endregion
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/* Velocidad con la que se mueve el plano */
		float amountToMove = Speed * Time.deltaTime;
		/* Trasladando el background en direccion down con recpecto a la nave */
		transform.Translate (Vector3.down * amountToMove);
		/* Revisa si el background esta offscreen  */
		if (transform.position.z < -20) {
			/* Recolocamos el background con respecto al eje Z en el valor de 30 */
			transform.position = new Vector3(transform.position.x,transform.position.y,30f);
		}
	}
}
