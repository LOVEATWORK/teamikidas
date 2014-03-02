using UnityEngine;
using System.Collections;

public class IkidasController : MonoBehaviour
{
	
	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		
		if (vertical > 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 2);
		} else if (vertical < 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 0);
		} else if (horizontal > 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 3);
		} else if (horizontal < 0) {
			animator.enabled = true;
			animator.SetInteger ("direction", 1);
		} else {
			animator.enabled = false;		
		}
	}
}
