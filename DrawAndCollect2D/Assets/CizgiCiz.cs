using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CizgiCiz : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Cizgi;

    public LineRenderer lineRenderer;
    public EdgeCollider2D EdgeCollider;
    public List<Vector2> ParmakPozisyonListesi;

    private void Update()
    {
        
    }

    void CizgiOlustur()
    {
        Cizgi = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
        lineRenderer = Cizgi.GetComponent<LineRenderer>();
        EdgeCollider = Cizgi.GetComponent<EdgeCollider2D>(); // top uzerinde dursun diye kullanicaz edgecollideri
        ParmakPozisyonListesi.Clear(); // Simdi ayni anda birden fazla cizgi cekmek isteyebilirsin o yuzden bir onceki cizgimizin bilgilerini sifirliyoruz.

        //EdgeCollider LineRendererda 2 farkli nokta arasinda caliscagimiz icin 2 tane aliyoruz parmagini sonucta bir noktadan baska bir noktaya surukliceksin
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //simdi lineRendererima ekle pozisyonu diyorum ilk pozisyonum 0 yani ekle bunu ParmakPozisyonListesindeki ilk elemani sonra bir altinda 2 ci elemani.
        lineRenderer.SetPosition(0, ParmakPozisyonListesi[0]);
        lineRenderer.SetPosition(1, ParmakPozisyonListesi[1]);

        EdgeCollider.points = ParmakPozisyonListesi.ToArray();

    }

    void CizgiyiGuncelle(Vector2 GelenParmakPozisyonu)
    {

    }
}
