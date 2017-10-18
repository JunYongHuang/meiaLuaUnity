using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float velocidade;
	public Transform caio;
	private Animator animator;
	private Rigidbody2D myBody;
	private GameObject caiete;

	public bool isGrounded;
	public float force;
	public float jumpTime = 0.4f;
	public float jumpDelay = 0.4f;
	public bool jumped;
	public Transform ground;

	// Use this for initialization
	void Start () {
	
		animator = caio.GetComponent<Animator>();
		myBody = GetComponent<Rigidbody2D>();
		caiete = GameObject.Find("caio");

	}
	
	// Update is called once per frame
	void Update () {

		Movimentar();
	
	}

	void Movimentar(){

		isGrounded = Physics2D.Linecast(this.transform.position,ground.position,1 << LayerMask.NameToLayer("PlataformaNivel2"));

		animator.SetFloat("run",Mathf.Abs(Input.GetAxis("Horizontal")));
		if (Input.GetAxis("Horizontal") > 0){
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			caiete.transform.eulerAngles = new Vector2(0,0);
		}

		if (Input.GetAxis("Horizontal") < 0){
			transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
			caiete.transform.eulerAngles = new Vector2(0,180);
		}

		if (Input.GetButtonDown("Jump") && isGrounded && !jumped){
			myBody.AddForce(transform.up * force);
			jumpTime = jumpDelay;
			animator.SetTrigger("jump");
			jumped = true;
		}

		jumpTime -= Time.deltaTime;

		if (jumpTime <= 0 && isGrounded && jumped){
			animator.SetTrigger("ground");
			jumped = false;
		}
}

}