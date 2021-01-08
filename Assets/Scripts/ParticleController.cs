using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    void Start() {
        StartCoroutine(DestroyParticle());
    }

    IEnumerator DestroyParticle() {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
