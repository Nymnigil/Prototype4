using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BonusDestroy());
    }

    IEnumerator BonusDestroy() 
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
