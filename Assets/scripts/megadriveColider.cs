using UnityEngine;
using System.Collections;

public class megadriveColider : MonoBehaviour {

	public int ponto = 5;
	public float tempoMaximoVida;
	public float tempoVida;

	public Vidas2 vida;
	private Score score;
	// Use this for initialization

	void Awake(){
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>() as Score;
	}

	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		tempoVida += Time.deltaTime;
		if (tempoVida >= tempoMaximoVida){
			Destroy(gameObject);
			tempoVida = 0;
		}
	
	}

	void OnCollisionEnter2D(Collision2D colisor){
		if (colisor.gameObject.tag == "Player"){

			vida = GameObject.FindGameObjectWithTag("Vidas2").GetComponent<Vidas2>() as Vidas2;

			if(vida.ExcluirVida()){

				score.Tirarponto(ponto);
				Destroy(gameObject);
			}else{
				//fazer gameover
			}
		}
	}
}
