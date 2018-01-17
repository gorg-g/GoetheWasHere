using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour 
{
    public bool isThrown = false;
    public bool isFlying = false;

    private Rigidbody rb;
    private float timeOutCounter;

	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        timeOutCounter = 0.0f;
	}
	
    void FixedUpdate ()
    {
        if (isThrown)
        {
            isFlying = StillFlying();
            timeOutCounter += Time.deltaTime;
        }
    }

    bool StillFlying()
    {
        if (rb.IsSleeping() || (transform.position.y <= -1.0f) || timeOutCounter > 10.0f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

	public void Throw (float angle, float magnitude) 
    {
        timeOutCounter = 0.0f;
        Vector3 throwForce = Quaternion.Euler(0.0f, 0.0f, angle) * (new Vector3(2.0f, 0.0f, 0.0f));
        throwForce = throwForce * magnitude;
        rb.useGravity = true;
        rb.AddForce(throwForce);
        isThrown = true;
	}

    public void StopMovement ()
    {
        StartCoroutine(RespawnBall());
    }

    private IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForFixedUpdate();
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        timeOutCounter = 0.0f;
        isThrown = false;
        isFlying = false;
    }
}
