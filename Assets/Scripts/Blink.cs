using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] Renderer[] _renderers;
    public void StartBlink()
    {
        StartCoroutine(Blinking());
    }
    public IEnumerator Blinking()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].material.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
               
            }
                yield return null;
        }
    }
}
