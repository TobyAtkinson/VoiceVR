using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadtank : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DeleteSelf());
    }

    IEnumerator DeleteSelf()
    {

        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);
    }
}
