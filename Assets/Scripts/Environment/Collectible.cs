using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public GameObject collectText; // Assign the Text UI element in the Inspector
    public float interactDistance = 2f; // Adjust the interaction distance as needed
    public KeyCode collectKey = KeyCode.E;
    public Transform collectible;
    public Transform playerBody;
    public bool canCollect = false;
    public string collectibleIngameName;

    private void Start()
    {
        if (collectibleIngameName == "")
            collectibleIngameName = this.gameObject.name;
        collectText.gameObject.SetActive(false);
        string displayCollectText = "Press " + collectKey.ToString() + " to collect " + collectibleIngameName; 
        collectText.GetComponent<TextMeshProUGUI>().text = displayCollectText;
    }


    private void OnDestroy()
    {
        collectText.gameObject.SetActive(false);
    }

    private void Update()
    {
        var distance = Vector3.Distance(collectible.position, playerBody.position);

        if (canCollect && Input.GetKeyDown(collectKey) && distance <= interactDistance)
        {
            Collect();
        }

        if (collectible.gameObject)
        {
            Debug.Log(collectible.name);

            if (distance <= interactDistance)
            {
                collectText.gameObject.SetActive(true);

            }
            else
            {
                collectText.gameObject.SetActive(false);
            }
        }
        else
        {
            collectText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = false;
        }
        collectText.gameObject.SetActive(false);
    }

    private void Collect()
    {
        collectText.gameObject.SetActive(false);
        Destroy(collectible.gameObject);

    }
}