using UnityEngine;

public class PickPetal : MonoBehaviour
{
    private PetalController petalController;

    public void OnPickPetal()
    {
        petalController = GameObject.FindWithTag("PetalController").GetComponent<PetalController>();
        petalController.PickPetal();
        Destroy(gameObject);
    }
}
