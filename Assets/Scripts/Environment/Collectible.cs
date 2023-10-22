using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public GameObject collectTextPrefab; // Assign the Text UI prefab element in the Inspector
    private GameObject collectText;
    public float interactDistance = 2f; // Adjust the interaction distance as needed
    public KeyCode collectKey = KeyCode.E;
    public Transform collectible;
    public Transform playerBody;
    public bool canCollect = false;
    public string collectibleIngameName;
    private float distance;
    private void Start()
    {
        collectText = Instantiate(collectTextPrefab, GameObject.Find("Main Camera").transform);


        if (collectibleIngameName == "")
            collectibleIngameName = this.gameObject.name;
        collectText.gameObject.SetActive(false);
        string displayCollectText = "Press " + collectKey.ToString() + " to collect " + collectibleIngameName; 
        collectText.GetComponent<TextMeshProUGUI>().text = displayCollectText;
    }


    private void OnDestroy()
    {
        if(collectText.gameObject)
        GameObject.Destroy(collectText.gameObject);
    }

    private void Update()
    {
       distance = Vector3.Distance(collectible.position, playerBody.position);
       Debug.Log(distance);

        if (canCollect && Input.GetKeyDown(collectKey) && distance <= interactDistance)
        {
            Collect();
        }

        if (collectible.gameObject)
        {
            if (distance <= interactDistance)
            {
                collectText.gameObject.SetActive(true);

            }
            else
            {
                collectText.gameObject.SetActive(false);
            }
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