using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public TextMeshProUGUI controlsTextBatteriesText;
        public TextMeshProUGUI controlsTextToolsText;
        public TextMeshProUGUI inspectTextUIObject;
        public TimedInterfaceText informationTextUIObject;
        private List<Collectible> Collectibles;
        private List<Interactable> Interactables;
        public Transform PlayerTransform;

        private bool showRelicPartCount = false;

        public void Awake()
        {
            if (Instance != null)
            {
                Instance.Reload();
                PlayerInventory.Instance.Reload();
                Destroy(gameObject);
                return;
            }

            Instance = this;

            Application.targetFrameRate = 144;

            Reload();

            DontDestroyOnLoad(gameObject);
        }

        private void Reload()
        {
            Collectibles = FindObjectsByType<Collectible>(FindObjectsSortMode.None).ToList();
            Interactables = FindObjectsByType<Interactable>(FindObjectsSortMode.None).ToList();

            foreach (var c in Collectibles)
            {
                c.Initialise();
                c.playerBody = PlayerTransform;
                c.OnCollected += Collectible_OnCollected;
                c.OnCollectFailed += Collectible_OnCollectFailed;
                c.OnInteracted += I_OnInteracted;
            }

            foreach (var i in Interactables)
            {
                i.Initialise();
                i.playerBody = PlayerTransform;
                i.OnPlayerNear += Collectible_OnPlayerNear;
                i.OnPlayerLeft += Collectible_OnPlayerLeft;
                i.OnInteracted += I_OnInteracted;
            }
        }

        private void I_OnInteracted(Interactable obj)
        {

        }

        private void Start()
        {
            ShowInformationText("Ouch my head... Where am I?");
        }

        private void Collectible_OnCollected(Collectible obj)
        {
            informationTextUIObject.ShowText($"Picked up {obj.Name}!\n{obj.CollectedText}");
        }

        private void Collectible_OnCollectFailed(Collectible c, string message)
        {
            informationTextUIObject.ShowText(message);
        }

        private void Collectible_OnPlayerLeft(Interactable obj)
        {
            if (inspectTextUIObject == null) return;

            inspectTextUIObject.text = "";
            inspectTextUIObject.gameObject.SetActive(false);
        }

        private void Collectible_OnPlayerNear(Interactable collectibleNearPlayer)
        {
            if (inspectTextUIObject == null) return;

            inspectTextUIObject.text = collectibleNearPlayer.InteractText;
            inspectTextUIObject.gameObject.SetActive(true);
        }

        public void ShowInformationText(string message)
        {
            informationTextUIObject.ShowText(message);
        }

        public void Update()
        {
            controlsTextBatteriesText.text = $"Batteries: {PlayerInventory.Instance.Batteries}";

            controlsTextBatteriesText.text += $"\nRelic Parts: { PlayerInventory.Instance.TotalKeys} ";

            var s = "";

            if (PlayerInventory.Instance.HelmentCollected)
            {
                 s += $"Sight Active";
            }

            if (PlayerInventory.Instance.JetPackCollected)
            {
                s += $"\nThrusters Downloaded";
            }

            controlsTextToolsText.text = s;
        }
    }
}
