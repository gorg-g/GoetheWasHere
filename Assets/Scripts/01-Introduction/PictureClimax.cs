using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureClimax : MonoBehaviour
{
    public Image thisImage;
    public float pictureMoveSpeed;

    public void Climax()
    {
        StartCoroutine(MoveImage());
    }

    IEnumerator MoveImage()
    {
        int i = 0;
        //float timer = 0.0f;

        while(i < 100)
        {
            float newX = Mathf.Max(thisImage.rectTransform.position.x - pictureMoveSpeed, 100.0f);
            thisImage.rectTransform.position = new Vector3(newX, thisImage.rectTransform.position.y, thisImage.rectTransform.position.z);

            //float scaleDelta = (float) (i/500.0f) * 0.2f * Mathf.Cos(timer * (2*Mathf.PI) * i/500) + 1.8f;
            //timer += Time.deltaTime;

            //thisImage.rectTransform.localScale = new Vector3(scaleDelta, scaleDelta, 1);

            i++;
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }
}