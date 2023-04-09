using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tolgay : MonoBehaviour
{
	private Animator anim;
	public AudioSource tolgay;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	private void OnMouseEnter()
	{
		anim.SetBool("hovered", true);
		tolgay.Play();
	}
	private void OnMouseDown()
	{
		SceneManager.LoadScene(3);
	}
}
