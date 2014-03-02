using UnityEngine;
using System.Collections;

public class IkidasSimpleController : MonoBehaviour {

	public float speed = 5;
	private Animator animator;
	private bool isMoving = false;
	private Vector2 input;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		input = new Vector2 (Input.GetAxis ("Horizontal") * Time.smoothDeltaTime * speed, Input.GetAxis ("Vertical") * Time.smoothDeltaTime * speed);

		if (!isMoving && input != Vector2.zero) {
			GameState.Instance.gameIsPaused = false;
			isMoving = true;
		}

		if (input.y > 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 2);
		} else if (input.y < 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 0);
		} else if (input.x > 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 3);
		} else if (input.x < 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 1);
		} else {
			animator.enabled = false;		
		}

		transform.Translate (input.x, input.y, 0, Space.Self);

	}
}
