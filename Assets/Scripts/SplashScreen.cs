using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreen : MonoBehaviour
{
    Image screenFill;
    void Start()
    {
        screenFill = this.gameObject.GetComponent<Image>();
        screenFill.DOFade(0, .2f);

        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.SP.OpenScene(1);
    }
}
