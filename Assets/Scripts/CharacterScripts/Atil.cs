using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Atil : MonoBehaviour
{
	private Animator anim;
	public AudioSource atil;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	private void OnMouseEnter()
	{
		anim.SetBool("hovered", true);
		atil.Play();
	}
	private void OnMouseDown()
	{
		SceneManager.LoadScene(2);
	}
}
