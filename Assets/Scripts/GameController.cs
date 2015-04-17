using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;					// Cantidad de meteoritos a desplegar
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int total;
	private int score;

	/* Init global variables */
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		total = 100; 
		UpdateScore ();
		/* Starting to spawn meteors */
		StartCoroutine (SpawnWaves ());
	}

	void Update () {

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}	
		}
	}
	/* Creating meteors */
	IEnumerator SpawnWaves ()
	{
		/*  Esperamos startWait segundos antes de desplegar meteoritos*/
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			/* Display meteors */
			for (int i = 0; i < hazardCount; i++)
			{
				/* Los meteoritos optienen su vector posicion de la intefaz */
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				/* Clona los meterorios */
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			/* If game is over */
			if(gameOver){
				/* Set message in UI */
				restartText.text="Press 'R' for Restart";
				restart = true;
				/* Reestablecemos la velocidad de los meteoritos a -5 */
				/*hazard.GetComponent<Mover>().speed = -5;
				hazardCount = 10;*/
				ResetSettings();
				/* Get out of while */
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		/* Si el score se incrementa  */
		if (score == total) {
			/* Incrementa la velocidad de los meteoritos */
			hazard.GetComponent<Mover>().speed += -5;
			/* Incrementa la cantidad de meteoritos */
			//hazardCount += 2;
			/* Reduce el tiempo de espera para mostrar meteoritos*/
			spawnWait += -0.1f;
			/* Reduce el tiempo de despliegue de meteoritos*/
			waveWait += -0.1f;
			total += 100;		
		}
		UpdateScore ();
	}
	
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOverText.text = "Game Over";
		gameOver = true;
	}
	/* Resetea el juego a sus configuracion inicial */
	private void ResetSettings(){
		hazard.GetComponent<Mover>().speed = -5;
		hazardCount = 10;
		spawnWait = 1f;
		waveWait = 2f;
	}
}
