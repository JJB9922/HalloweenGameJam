using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    // Inventory items
    private int batteries;
    private int memories;
    public GameObject ControlsTextBatteries;

    public int Batteries
    {
        get { return batteries; }
    }

    public int Memories
    {
        get { return memories; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        batteries = 0;
        memories = 0;
        ControlsTextBatteries.GetComponent<TextMeshProUGUI>().text = "Batteries: " + batteries.ToString();
        DontDestroyOnLoad(gameObject);
    }

    public void IncrementBatteries(int amount)
    {
        batteries += amount;
        Debug.Log("added " + amount + " batteries to inventory");
        ControlsTextBatteries.GetComponent<TextMeshProUGUI>().text = "Batteries: " + batteries.ToString();
    }

    public void DecrementBatteries(int amount)
    {
        batteries = Mathf.Max(batteries - amount, 0);
        ControlsTextBatteries.GetComponent<TextMeshProUGUI>().text = "Batteries: " + batteries.ToString();
    }

    public void IncrementMemories(int amount)
    {
        memories += amount;
    }

    public void DecrementMemories(int amount)
    {
        memories = Mathf.Max(memories - amount, 0);
    }
}
