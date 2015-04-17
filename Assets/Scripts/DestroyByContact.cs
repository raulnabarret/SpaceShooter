using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		/* si la colision es con bondary, la omitimos*/
		if (other.tag == "Boundary")
		{
			return;
		}
		/* Despliega la explosion en la posicion del meteorito */
		Instantiate(explosion, transform.position, transform.rotation);
		/* Si la colision es con el jugador, destruye al jugador y termina el juego */
		if (other.tag == "Player")
		{
			/* Despliega la explision en la posicion de la nave */
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue);
		/* Destruye el disparo de la nave */
		Destroy(other.gameObject);
		/* Destruye el meteorito */
		Destroy(gameObject);
	}
}