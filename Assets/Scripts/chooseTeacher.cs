using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseTeacher : MonoBehaviour
{
    public void omerabi()
	{
		SceneManager.LoadScene(5);
	}
	public void atil()
	{
		SceneManager.LoadScene(2);
	}
	public void tolgay()
	{
		SceneManager.LoadScene(3);
	}
	public void sonat()
	{
		SceneManager.LoadScene(4);
	}
	public void sertifika()
	{
		SceneManager.LoadScene(1);
	}
}
