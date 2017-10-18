using UnityEngine;
using System.Collections;


public class water : MonoBehaviour {

	private GameObject water1;
	private GameObject water2;

	private float timeMovimento = 0;
	public float mxDelay;
	private bool isCima = true;
	// Use this for initialization
	void Start () {
	
		water1 = GameObject.Find("waterNivel1");
		water2 = GameObject.Find("waterNivel2");

	}
	
	// Update is called once per frame
	void Update () {



		timeMovimento += Time.deltaTime;
		if (timeMovimento <= mxDelay){
			
			if (isCima){
				transform.Translate(Vector2.up * 0.04f * Time.deltaTime);
				water1.transform.Translate(Vector2.up * 0.08f * Time.deltaTime);
				water2.transform.Translate(Vector2.up * 0.04f * Time.deltaTime);
			}else {
				transform.Translate(-Vector2.up * 0.04f * Time.deltaTime);
				water1.transform.Translate(-Vector2.up * 0.08f * Time.deltaTime);
				water2.transform.Translate(-Vector2.up * 0.04f * Time.deltaTime);
			}
		}else {
			isCima = !isCima;
			timeMovimento = 0;
		}

	}
}
