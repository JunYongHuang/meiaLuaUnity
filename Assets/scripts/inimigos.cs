using UnityEngine;
using System.Collections;

public class inimigos : MonoBehaviour {

	public GameObject objeto;
	private bool isEsquerda = true;
	public float velocidade = 5f;
	public float mxDelay;
	private GameObject andre;

	private float timeMovimento = 0f;

	public Transform verticeInicial;
	public Transform verticeFinal;
	public bool isAlvo;

	private float mxDelayObjeto = 0.001f;
	private float timeObjeto = 10f;

	private Animator animator;


	// Use this for initialization
	void Start () {

		andre = GameObject.Find("andre");
		animator = andre.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		Movimentar();
		RayCasting();
		Behaviours();
	}

	void RayCasting(){
		Debug.DrawLine(verticeInicial.position, verticeFinal.position,Color.red);
		isAlvo = Physics2D.Linecast (verticeInicial.position,verticeFinal.position,
		                             1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours(){
			if (isAlvo){
				if (timeObjeto <= mxDelayObjeto){
				animator.SetTrigger("atira");
				Debug.Log("timeObjeto: "+timeObjeto);
				timeObjeto += Time.deltaTime;
				Instantiate(objeto,verticeInicial.position, objeto.transform.rotation);
				}
			}else {
			timeObjeto = 0;
			animator.SetTrigger("naoAtira");
		}
	}


	void Movimentar(){
		
		timeMovimento += Time.deltaTime;
		if (timeMovimento <= mxDelay){
			
			if (isEsquerda){
				transform.Translate(Vector2.right * velocidade * Time.deltaTime);
				andre.transform.eulerAngles = new Vector2(0,180);
				
			}else {
				transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
				andre.transform.eulerAngles = new Vector2(0,0);
			}
		}else {
			isEsquerda = !isEsquerda;
			timeMovimento = 0;
		}
	}
}
