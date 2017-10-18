using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int ponto;
	public static Score instance;
	public GUIText textRender;
	
	void Awake(){
		instance = this;
	}
	
	// Use this for initialization
	void Start () {

		textRender = GetComponent<GUIText>();
		textRender.text = "Pontos:  " + ponto;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SomarPonto(int _ponto){
		ponto += _ponto;
		textRender.text = "Pontos:  " + ponto;
	}
	public void Tirarponto(int _ponto){
		ponto -= _ponto;
		textRender.text = "Pontos:  " + ponto;
	}
	
	public static void Inicializar(){
		ponto = 0;
	}
}
