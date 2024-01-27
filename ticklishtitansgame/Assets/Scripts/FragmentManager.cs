using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{
    private List<GameObject> fragments = new List<GameObject>();
    [Tooltip("Seconds til items de-spawn")]
    [SerializeField]float timeToDestroy = 5f;//seconds til destroy

    void Update()
    {
        GameObject[] allFragments = GameObject.FindGameObjectsWithTag("Fragment");
        foreach (GameObject fragment in allFragments)
        {
            if (!fragments.Contains(fragment))
            {
                // New fragment found, add to list and start coroutine to destroy it
                fragments.Add(fragment);
                StartCoroutine(DestroyAfterTime(fragment, timeToDestroy));
            }
        }
    }

    private IEnumerator DestroyAfterTime(GameObject fragment, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Before destroying, check if the fragment still exists
        if (fragment != null)
        {
            fragments.Remove(fragment);
            Destroy(fragment);
        }
    }
}
