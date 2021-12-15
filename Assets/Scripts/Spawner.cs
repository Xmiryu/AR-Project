using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [Min(1)]
    [SerializeField] private float delay;
    private void OnEnable ()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn ()
    {
        yield return null;
        while(true)
        {
            yield return new WaitForSeconds(delay);
            var sphere = Instantiate(this.sphere);
            sphere.transform.position = this.transform.position;
        }
    }

    public void Show ()
    {
        gameObject.SetActive(true);
        transform.position = Camera.main.transform.position + Camera.main.transform.forward;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
