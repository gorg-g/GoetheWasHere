using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPPlayerController : MonoBehaviour 
{
    private ThrowBall ball;
    private Transform arrowTrans;

    private Vector3 playerInitPositionLoc = new Vector3(3.0f, 0.25f, 0.0f);
    private Vector3 newPosition;
    private float distanceCameraPlayer;
    private float timer;
    private Camera cam;
    private bool isRespawning = false;

	void Start () 
    {
        GameObject ballGO = GameObject.FindWithTag("Ball");
        if (ballGO != null)
        {
            ball = ballGO.GetComponent<ThrowBall>();
        }

        GameObject arrowGO = GameObject.FindWithTag("Arrow");
        if (arrowGO != null)
        {
            arrowTrans = arrowGO.GetComponent<Transform>();
        }

        transform.localPosition = playerInitPositionLoc;

        cam = Camera.main;

        timer = 0.0f;
	}
	
	public void Move (Vector3 inputPosition) 
    {
        if (ball.isThrown == false && isRespawning == false)
        {
            distanceCameraPlayer = (cam.transform.position - transform.position).magnitude;
            newPosition = cam.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, distanceCameraPlayer));
            transform.position = new Vector3(transform.position.x, transform.position.y, newPosition.z);

            Vector3 playerOnScreen = cam.WorldToScreenPoint(transform.position);
            float arrowLength = Mathf.Clamp((playerOnScreen.y / inputPosition.y), 1.0f, 3.0f) * 5;
            arrowTrans.localScale = new Vector3(arrowTrans.localScale.x, arrowLength, arrowTrans.localScale.z);
            arrowTrans.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f * 0.5f * (1.0f + Mathf.Cos(timer)));
            timer = timer + Time.deltaTime;
        }
	}

    public void Throw ()
    {
        if (ball.isThrown == false && isRespawning == false)
        {
            float angle = 90.0f + arrowTrans.localEulerAngles.z;
            float magnitude = arrowTrans.localScale.y / 10.0f;
            ball.Throw(angle, magnitude);
        }
    }

    public void CheckMovement ()
    {
        if (ball.isThrown == true && ball.isFlying == false && isRespawning == false)
        {
            isRespawning = true;
            ball.StopMovement();
            StartCoroutine(RespawnArrow());
            timer = 0.0f;
        }
    }

    private IEnumerator RespawnArrow()
    {
        yield return new WaitForSeconds(1);
        transform.localPosition = playerInitPositionLoc;
        arrowTrans.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        arrowTrans.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        isRespawning = false;
    }
}
