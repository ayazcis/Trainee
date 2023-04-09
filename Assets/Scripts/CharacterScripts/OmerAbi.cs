using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OmerAbi : MonoBehaviour
{
	private Animator anim;
	public AudioSource omer;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	private void OnMouseEnter()
	{
		anim.SetBool("hovered", true);
		omer.Play();
	}
	private void OnMouseDown()
	{
		SceneManager.LoadScene(4);
	}
}
