using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour 
{
    [HideInInspector]
    public bool isThrown = false;
    [HideInInspector]
    public bool isFlying = false;

    private Rigidbody rb;
    private Vector3 lastPos;

	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
	}
	
    void FixedUpdate ()
    {
        if (isThrown)
        {
            isFlying = StillFlying();
        }
    }

    bool StillFlying()
    {
        float deltaY = lastPos.y - transform.position.y;
        lastPos = transform.position;

        if (((deltaY < Mathf.Pow(10, -6)) && (deltaY >= 0)) || (transform.position.y <= 0.0f))
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
        Vector3 throwForce = Quaternion.Euler(0.0f, 0.0f, angle) * (new Vector3(2.0f, 0.0f, 0.0f));
        throwForce = throwForce * magnitude;
        rb.useGravity = true;
        rb.AddForce(throwForce);
        isThrown = true;
	}

    public void StopMovement ()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        isThrown = false;
        StartCoroutine(RespawnBall());

    }

    private IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(1);
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
