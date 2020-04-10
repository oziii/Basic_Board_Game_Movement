using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
	int randVal;
	private float timeInterval;
	private bool isCoroutine;
	public int finalAngle;
	public int stepNumber;

	public int section;
	float totalAngle;

	private void Start()
	{
		isCoroutine = true;
		totalAngle = 360 / section;
	}
	private void Update()
	{

		if (Input.GetMouseButton(0) && isCoroutine)
		{
			StartCoroutine(SpinWheel());		
		}
	}

	private IEnumerator SpinWheel()
	{

		isCoroutine = false;
		randVal = Random.Range(200, 300);

		timeInterval = 0.0001f * Time.deltaTime * 2;

		for (int i = 0; i < randVal; i++)
		{

			transform.Rotate(0, 0, (totalAngle / 2));

			if (i > Mathf.RoundToInt(randVal * 0.2f))
				timeInterval = 0.5f * Time.deltaTime;
			if (i > Mathf.RoundToInt(randVal * 0.5f))
				timeInterval = 1f * Time.deltaTime;
			if (i > Mathf.RoundToInt(randVal * 0.7f))
				timeInterval = 1.5f * Time.deltaTime;
			if (i > Mathf.RoundToInt(randVal * 0.8f))
				timeInterval = 2f * Time.deltaTime;
			if (i > Mathf.RoundToInt(randVal * 0.9f))
				timeInterval = 2.5f * Time.deltaTime;

			yield return new WaitForSeconds(timeInterval);

		}

		if (Mathf.RoundToInt(transform.eulerAngles.z) % totalAngle != 0) 
			transform.Rotate(0, 0, totalAngle / 2);

		finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
		stepNumber = (finalAngle / (section*10) )+1;
		print(stepNumber);

		

		isCoroutine = true;
		StartCoroutine(GameObject.Find("Hero").GetComponent<Move>().MoveTo());
	}

}
