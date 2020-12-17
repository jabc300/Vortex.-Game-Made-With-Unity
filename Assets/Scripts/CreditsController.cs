using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public GameObject creditsInfo;
    public GameObject creditsSongs;
    public GameObject creditsThanks;
    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine("CreditsChange");
    }

    private void OnDisable()
    {
        StopCoroutine("CreditsChange");
    }

    private IEnumerator CreditsChange() {
        while (gameObject.activeInHierarchy)
        {
            creditsThanks.SetActive(false);
            creditsInfo.SetActive(true);
            yield return new WaitForSeconds(5);
            creditsInfo.SetActive(false);
            creditsSongs.SetActive(true);
            yield return new WaitForSeconds(6);
            creditsSongs.SetActive(false);
            creditsThanks.SetActive(true);            
            yield return new WaitForSeconds(5);
        }
        yield return null;
    }
}
