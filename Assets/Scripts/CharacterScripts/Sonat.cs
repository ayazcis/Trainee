using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sonat : MonoBehaviour
{
	private Animator anim;
	public AudioSource sonat;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	private void OnMouseEnter()
	{
		anim.SetBool("hovered", true);
		sonat.Play();
	}
	private void OnMouseDown()
	{
		SceneManager.LoadScene(5);
	}
}
