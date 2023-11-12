using Assets.Scripts;
using Assets.Scripts.Collectibles;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    // Inventory items
    private int batteries;
    private int memories;
    public GameObject ControlsTextBatteries;
    public List<Collectible> Items;
    public bool HelmentCollected => Items.Where(c => c.GetType() == typeof(Helmet)).Count() == 1;
    public int Batteries => Items.Where(c => c != null && c.GetType() == typeof(Battery)).Count();
    public int Memories => Items.Where(c => c != null && c.GetType() == typeof(Memory)).Count();
    public int TotalKeys => Items.Where(c => c != null && c.GetType() == typeof(RelicPart) || c.GetType() == typeof(BatteryForRelic)).Count();
    public bool JetPackCollected => Items.Where(c => c.GetType() == typeof(JetPack)).Count() == 1;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Instance.Reload();
            return;
        }

        Instance = this;

        Reload();

        DontDestroyOnLoad(gameObject);
    }

    public void Reload()
    {
        Items = new();

        var collectibles = FindObjectsByType<Collectible>(FindObjectsSortMode.None).ToList();

        foreach (var c in collectibles)
        {
            c.OnCollected += Collectible_OnCollected;
        }

        ControlsTextBatteries.GetComponent<TextMeshProUGUI>().text = "Batteries: " + batteries.ToString();

    }

    private void Collectible_OnCollected(Collectible collectible)
    {
        Items.Add(collectible);
    }

    public void DecrementBatteries(int amount)
    {
        // todo this
    }
}
