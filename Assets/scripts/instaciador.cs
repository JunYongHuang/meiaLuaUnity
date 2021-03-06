﻿using UnityEngine;
using System.Collections;

public class instaciador : MonoBehaviour {

	public GameObject[] objetos;
	private bool isEsquerda = true;
	public float velocidade = 5f;
	public float mxDelay;

	public float InstanciadorTempo = 5f;
	public float instanciadorDelay = 3f;

	private float timeMovimento = 0f;
	public int valorMinimoRandom = 0;
	// Use this for initialization
	void Start () {
	
		InvokeRepeating("Spawn", InstanciadorTempo, instanciadorDelay);

	}
	
	// Update is called once per frame
	void Update () {
	
		Movimentar();

	}


	void Spawn(){

		int index = Random.Range (valorMinimoRandom,objetos.Length);
		Instantiate(objetos[index],transform.position,objetos[index].transform.rotation);
	}

	void Movimentar(){

		timeMovimento += Time.deltaTime;
		if (timeMovimento <= mxDelay){

			if (isEsquerda){
				transform.Translate(Vector2.right * velocidade * Time.deltaTime);	
				}else {
				transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
			}
		}else {
			isEsquerda = !isEsquerda;
			timeMovimento = 0;
		}
	}
}
