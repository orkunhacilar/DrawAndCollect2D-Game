using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("---TOP VE TEKNIK OBJELER")]
    [SerializeField] private TopAtar _TopAtar;
    [SerializeField] private CizgiCiz _CizgiCiz;
    [Header("---GENEL OBJELER")]
    [SerializeField] private ParticleSystem KovaGirme;
    [SerializeField] private ParticleSystem BestScoreGecis;
    [SerializeField] private AudioSource[] sesler;
    [Header("---UI OBJELER")]
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private TextMeshProUGUI[] ScoreTextleri;

    int GirenTopSayisi;




   

    // Start is called before the first frame update
    void Start()
    {
      

        if (PlayerPrefs.HasKey("BestScore"))
        {
            ScoreTextleri[0].text = PlayerPrefs.GetInt("BestScore").ToString();
            ScoreTextleri[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
            ScoreTextleri[0].text = "0";
            ScoreTextleri[1].text = "0";
        }
    }


    public void DevamEt(Vector2 pos)
    {

        KovaGirme.transform.position = pos;
        KovaGirme.gameObject.SetActive(true);
        KovaGirme.Play();

        GirenTopSayisi++;
        sesler[1].Play();
        _TopAtar.DevamEt();
        _CizgiCiz.DevamEt();

    }

    public void OyunBitti()
    {

        sesler[3].Play();
        Paneller[1].SetActive(true);
        Paneller[2].SetActive(false);
        Debug.Log("KAYBETTIN");

        ScoreTextleri[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        ScoreTextleri[2].text = GirenTopSayisi.ToString();

        if (GirenTopSayisi > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", GirenTopSayisi);
            BestScoreGecis.gameObject.SetActive(true);
            BestScoreGecis.Play();
            
        }

        _TopAtar.TopAtmaDurdur();
        _CizgiCiz.CizmeyiDurdur();
     
    }

    public void OyunBaslasin()
    {
        Paneller[0].SetActive(false);
        _TopAtar.OyunBaslasin();
        _CizgiCiz.CizmeyiBaslat();
        Paneller[2].SetActive(true);
    }


    public void TekrarOyna()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
