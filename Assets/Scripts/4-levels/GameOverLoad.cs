using UnityEngine;

[RequireComponent(typeof(NumberField))]
public class GameOverLoad : MonoBehaviour
{
    void Start()
    {
        // read last score from PlayerPrefs
        int s = PlayerPrefs.GetInt("FinalScore", 0);

        // write it into the NumberField on this object
        NumberField nf = GetComponent<NumberField>();
        nf.SetNumber(s);
    }
}