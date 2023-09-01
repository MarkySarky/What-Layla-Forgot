using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BloodVialsCollectibles : MonoBehaviour
{
    public static BloodVialsCollectibles instance;
    public TMP_Text bloodText;
    public int currentBloodVials;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bloodText.text = currentBloodVials.ToString();
    }

    // Update is called once per frame
    public void IncreaseBloodVials(int b)
    {
        currentBloodVials +=b;
        bloodText.text = currentBloodVials.ToString();
    }
}
