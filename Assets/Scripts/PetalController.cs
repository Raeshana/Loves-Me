using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using TMPro;

public class PetalController : MonoBehaviour
{
    [Header("Petal prefabs")]
    [SerializeField] Image petalLong;
    [SerializeField] Image petalMed;
    [SerializeField] Image petalShort;

    [Header("Petal folders")]
    [SerializeField] Transform petalParentLong;
    [SerializeField] Transform petalParentMed;
    [SerializeField] Transform petalParentShort;

    [SerializeField] Transform petalSpawner;
    private bool lovesMe;
    [SerializeField] TMP_Text header;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GeneratePetals(petalLong, petalParentLong, 16, 20, 24.5f);
        GeneratePetals(petalMed, petalParentMed, 10, 18, 45);
        GeneratePetals(petalShort, petalParentShort, 8, 16, 45);

        lovesMe = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            
        }
    }

    private void GeneratePetals(Image petal, Transform petalParent, int rangeMin, int rangeMax, float angleIncrement)
    {
        // Randomize number of petals to generate 
        // Call GeneratePetal for each quadrant
        var petals = Random.Range(rangeMin, rangeMax);
        float minAngle = 0;
        for (int i = 0; i < petals; i++)
        {
            float mod = 360 / angleIncrement;
            float maxAngle = angleIncrement * (i % mod);
            GeneratePetal(petal, petalParent, minAngle, maxAngle);
            minAngle = maxAngle;
        }
    }

    private void GeneratePetal(Image petal, Transform petalParent, float minAngle, float maxAngle)
    {
        // Randomize angle
        // Generate quaternion for angle
        // Instantiate petal using angle
        Quaternion randAngle = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(minAngle, maxAngle));
        Instantiate(petal, petalSpawner.position, randAngle, petalParent);
    }

    public void PickPetal()
    {
        if (lovesMe)
        {
            header.text = "Loves me";
        }
        else
        {
            header.text = "Loves me not";
        }
        lovesMe = !lovesMe;
    }
}
