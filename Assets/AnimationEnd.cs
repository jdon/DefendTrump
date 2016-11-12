using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : MonoBehaviour {

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }
}
