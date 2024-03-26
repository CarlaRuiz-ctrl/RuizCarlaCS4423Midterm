using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class tokenCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI tokenCounterText;
    public static tokenCounter singleton;
    int tokensCollected = 0;

    private void Awake()
    {
        if (singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    public void UpdateCoin()
    {
        tokensCollected += 1;
        tokenCounterText.text = tokensCollected.ToString();
    }
    public void DecreaseCoin()
    {
        tokensCollected = Mathf.Max(0, tokensCollected - 1); // Prevents the token count from going below 0
        tokenCounterText.text = tokensCollected.ToString();
    }
}
