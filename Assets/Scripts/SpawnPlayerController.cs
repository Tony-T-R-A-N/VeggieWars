using UnityEngine;

public class SpawnPlayerController : MonoBehaviour {

    public GameObject[] vegetables;
    private GameObject currentVegetable;
    private int currentVegetableIndex = 0;

    void Start() {
        currentVegetable = Instantiate(vegetables[currentVegetableIndex], gameObject.transform.position, Quaternion.identity);
    }

    public void SwitchVegetable(int index) {
        currentVegetableIndex = index;
        Destroy(currentVegetable);
        currentVegetable = Instantiate(vegetables[currentVegetableIndex], gameObject.transform.position, Quaternion.identity);
    }
}
