using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class TimedInterfaceText : MonoBehaviour 
    {
        public TextMeshProUGUI UIText;

        public void Awake()
        {
            UIText = GetComponent<TextMeshProUGUI>();
        }

        public void ShowText(string message)
        {
            if (UIText == null) return;

            UIText.text = message;

            gameObject.SetActive(true);

            StartCoroutine(RemoveAfterSeconds(5));
        }

        IEnumerator RemoveAfterSeconds(int seconds)
        {
            yield return new WaitForSeconds(seconds);

            gameObject.SetActive(false);
        }
    }
}
