using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundAndAnim : MonoBehaviour
{
    public AudioSource sound;
	private Animator anim;
	public GameObject idleanimObject;
	private void Awake()
	{
		anim = idleanimObject.GetComponent<Animator>();
	}
	public void hovered_()
	{
		sound.Play();
		anim.SetBool("hovered", true);
	}
}
