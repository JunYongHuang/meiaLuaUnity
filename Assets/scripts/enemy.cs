using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public AudioClip clip;
	private float timeVida;
	public float tempoMaximoVida;
	private Score score;
	private int ponto = 1;

	void Awake(){
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>() as Score;
	}

	void Start () {
	
		timeVida = 0;
	}
	
	// Update is called once per frame
	void Update () {

		timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida){
			Destroy(gameObject);
			timeVida = 0;
		}
	
	}

	void OnCollisionEnter2D(Collision2D colisor){

		if (colisor.gameObject.tag == "Player"){

			score.SomarPonto(ponto);
			Destroy(gameObject);

		}
	}
}