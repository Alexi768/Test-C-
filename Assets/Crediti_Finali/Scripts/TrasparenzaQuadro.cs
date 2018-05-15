using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrasparenzaQuadro : MonoBehaviour
{
    float distance;
    [Header("Parametri Pilastri")]
    public float effectDistance;
    PlayerMove character;
    bool attivaEffetto;
    float tempoeffettoComparsa;
    float tempoeffettoSparizione;
    public float maxTimeSparizione;
    public float maxTimeApparizione;
    public float tempoComparsaPilastro;
    float timer;
    [Header("Parametri pos Pilastri")]
    public Transform minPosition;
    public Transform maxPosition;
    public GameObject oggettoDaSpostare;
    Image ImageQuadro;
    float frazioneScomparsa;
    float frazioneComparsa;
     float frazione;
    // Use this for initialization
    void Start()
    {
        oggettoDaSpostare.transform.position = minPosition.transform.position;
        character = FindObjectOfType<PlayerMove>();
        ImageQuadro = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position, character.transform.position);
        if (distance < effectDistance)
        {
            attivaEffetto = true;
        }
        else
        {
           
        }

        if (attivaEffetto)
        {
            tempoeffettoComparsa += Time.deltaTime;
            tempoeffettoSparizione = 0f;
           
            timer+= Time.deltaTime;
            frazione =timer/ tempoComparsaPilastro;
            frazioneComparsa = tempoeffettoComparsa / maxTimeApparizione;
            oggettoDaSpostare.transform.position = Vector3.Lerp(minPosition.position, maxPosition.position, frazione);
            Color startColor = ImageQuadro.color;
            startColor.a = Mathf.Lerp(0, 1, frazioneComparsa);
            ImageQuadro.color = startColor;
        }
        else
        {
            tempoeffettoSparizione += Time.deltaTime;
            tempoeffettoComparsa = 0f;
            frazioneScomparsa = tempoeffettoSparizione / maxTimeSparizione;
            Color startColor = ImageQuadro.color;
            startColor.a = Mathf.Lerp(1, 0, frazioneScomparsa);
            ImageQuadro.color = startColor;
        }
    }
}
