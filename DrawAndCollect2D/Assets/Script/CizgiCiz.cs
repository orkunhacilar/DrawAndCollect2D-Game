using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CizgiCiz : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Cizgi;

    public LineRenderer lineRenderer;
    public EdgeCollider2D EdgeCollider;
    public List<Vector2> ParmakPozisyonListesi;

    public List<GameObject> Cizgiler;
    bool CizmekMumkunmu;
    int CizmeHakki;
    [SerializeField] private TextMeshProUGUI CizmeHakkiText;

    private void Start()
    {
        CizmekMumkunmu = false;
        CizmeHakki = 3;
        CizmeHakkiText.text = CizmeHakki.ToString();
    }

    private void Update()
    {

        if (CizmekMumkunmu && CizmeHakki != 0)
        {
            if (Input.GetMouseButtonDown(0)) // sol click basildigi anda
            {
                CizgiOlustur();
            }
            if (Input.GetMouseButton(0)) // sol click basili tutuldugu anda
            {
                Vector2 ParmakPozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (Vector2.Distance(ParmakPozisyonu, ParmakPozisyonListesi[^1]) > .1f) // kontrol saglayiorum son pozisyon ile yeni parmak noktam arasindaki mesafe buyukse cizmeye devam et
                {
                    CizgiyiGuncelle(ParmakPozisyonu);
                }
            }
        }

        if(Cizgiler.Count!=0 && CizmeHakki != 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                CizmeHakki--;
                CizmeHakkiText.text = CizmeHakki.ToString();
            }
        }
       
    }

    void CizgiOlustur()
    {
        Cizgi = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
        Cizgiler.Add(Cizgi);
        lineRenderer = Cizgi.GetComponent<LineRenderer>();
        EdgeCollider = Cizgi.GetComponent<EdgeCollider2D>(); // top uzerinde dursun diye kullanicaz edgecollideri
        ParmakPozisyonListesi.Clear(); // Simdi ayni anda birden fazla cizgi cekmek isteyebilirsin o yuzden bir onceki cizgimizin bilgilerini sifirliyoruz.

        //EdgeCollider LineRendererda 2 farkli nokta arasinda caliscagimiz icin 2 tane aliyoruz parmagini sonucta bir noktadan baska bir noktaya surukliceksin
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //simdi lineRendererima ekle pozisyonu diyorum ilk pozisyonum 0 yani ekle bunu ParmakPozisyonListesindeki ilk elemani sonra bir altinda 2 ci elemani.
        lineRenderer.SetPosition(0, ParmakPozisyonListesi[0]);
        lineRenderer.SetPosition(1, ParmakPozisyonListesi[1]);

        EdgeCollider.points = ParmakPozisyonListesi.ToArray(); //Cizgiyi guncelle metodunda anlattim.

    }

    void CizgiyiGuncelle(Vector2 GelenParmakPozisyonu)
    {
        ParmakPozisyonListesi.Add(GelenParmakPozisyonu);
        lineRenderer.positionCount++; //misal 3 tane noktam var parmagimi uzattigim zaman bana 4. nokta lazim de mi onun icin bunu artiriyorum.

        //CizgiOlusturda lineRenderer'a degerler ekledik lineRenderer.SetPosition(0, ParmakPozisyonListesi[0]); gibi
        //Fakat 0 dan basladigi icin bir cikarip son verisine bizim yeni verimizi yani GelenParmakPozisyonumuzu ekliyorum.
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, GelenParmakPozisyonu);

        //EdgeCollider.points: -> EdgeCollider bileşenine ait noktaların (vertex'lerin) pozisyonlarını temsil eden bir diziye erişmek için kullanılır.
        //ToArray() metodu, bir listenin elemanlarını bir diziye dönüştürür. Yani, ParmakPozisyonListesi listesinde bulunan elemanlar bir diziye aktarılır.
        //EdgeCollider.pointsi sey diye dusun icinde array olarak 3 nokta var misal her noktanin x ve y degeri var. birinci nokta baska degerler ikinci nokta baska degerler bunlar birlesip collider ciziliyo gibi dusun iste biz ona degerleri atadik.
        EdgeCollider.points = ParmakPozisyonListesi.ToArray();
    }

    public void DevamEt()
    {
        foreach (var item in Cizgiler)
        {
            Destroy(item.gameObject);
        }
        Cizgiler.Clear();

        CizmeHakki = 3;
        CizmeHakkiText.text = CizmeHakki.ToString();
    }

    public void CizmeyiDurdur()
    {
        CizmekMumkunmu = false;
    }

    public void CizmeyiBaslat()
    {
        CizmeHakki = 3;
        CizmekMumkunmu = true;
    }

}
