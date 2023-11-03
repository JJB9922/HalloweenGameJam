using System;
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
    public int audioManagerClipID;  // the AI will say the name of the object when in sight
    public GameObject EnableObjectOnCollect; // enables a game object when this object is collected. e.g. used for the helmet
    private void Start()
    {
        collectText = Instantiate(collectTextPrefab, GameObject.Find("UI").transform);


        if (collectibleIngameName == "")
            collectibleIngameName = this.gameObject.name;

        string displayCollectText = "Press " + collectKey.ToString() + " to collect " + collectibleIngameName;
        TextMeshProUGUI colText = collectText.GetComponentInChildren<TextMeshProUGUI>();
        colText.text = displayCollectText;
        collectText.gameObject.SetActive(false);
    }


    private void OnDestroy()
    {
        if (collectText.gameObject)
            GameObject.Destroy(collectText.gameObject);
    }

    private void Update()
    {
        distance = Vector3.Distance(collectible.position, playerBody.position);



        if (distance <= interactDistance)
        {
            if (!collectText.gameObject.active)

            {
                collectText.gameObject.SetActive(true);
             
            }
            if (canCollect && Input.GetKeyDown(collectKey))
            {
                Collect();
            }
        }
        else
        {
            collectText.gameObject.SetActive(false);
        }
    }


    protected virtual void Collect()
    {

        // this is so bad - needs event system:
        if (collectibleIngameName == "Batteries")
        {
            PlayerInventory.Instance.IncrementBatteries(1);
        }

            // collect sound
            if (audioManagerClipID != null) AudioManager.instance.PlaySoundEffect(audioManagerClipID);
        if (EnableObjectOnCollect != null) EnableObjectOnCollect.gameObject.SetActive(true);
        collectText.gameObject.SetActive(false);
        Destroy(collectible.gameObject);
       

    }
}