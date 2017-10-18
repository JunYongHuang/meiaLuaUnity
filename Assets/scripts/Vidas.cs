using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {

	public Sprite[] sprites;
	private int _vidas;
	private int contador;
	private SpriteRenderer spriteRender;
	
	
	// Use this for initialization
	void Start () {
		spriteRender = GetComponent<SpriteRenderer> ();
		spriteRender.sprite = sprites [0];
		_vidas = sprites.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool ExcluirVida(){

		if(_vidas < 0){
			return false;
		}

		if (contador < (_vidas - 1)) {
			contador += 1;
			spriteRender.sprite = sprites [contador];
			return true;
		} else {
			return false;
		}
	}

}
