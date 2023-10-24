using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopAtar : MonoBehaviour
{
    [SerializeField] private GameObject[] Toplar;
    [SerializeField] private GameObject TopAtarMerkezi;
    [SerializeField] private GameObject Kova;
    [SerializeField] private GameObject[] KovaNoktalari;
    int AktifTopIndex;
    int RandomKovaPointIndex;

   // Vector2 point;  RASGELE KOVA CIKARMA

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Toplar[AktifTopIndex].transform.position = TopAtarMerkezi.transform.position;
            Toplar[AktifTopIndex].SetActive(true);


            //Vector3.forward ve Vector3.right : Bunlar Unity içinde vektörlerdir.
            //Vector3.forward dünya koordinat sistemine göre z ekseninin pozitif yönünde olan bir vektördür. Vector3.right ise x ekseninin pozitif yönünde olan bir vektördür.
            float aci = Random.Range(70f, 110f);
            Vector3 Pos = Quaternion.AngleAxis(aci, Vector3.forward) * Vector3.right;
            //Quaternion.AngleAxis(angle, axis) : Bu birim dönüş Quaternion'u oluşturur.
            //angle parametresi dönüş açısını belirtir ve axis parametresi dönüşün etkileyeceği eksenin yönünü belirtir. Bu fonksiyon, dönüşü temsil etmek için kullanılır.
            Toplar[AktifTopIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(750 * Pos); //pos * rakamı terste yazabılıyon böyle


            //    Toplar[AktifTopIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 500); // topu fırlatmak için yazdık.

            if (AktifTopIndex != Toplar.Length - 1)
            {
                AktifTopIndex++;
            }
            else
            {
                AktifTopIndex = 0;
            }
           // point = Random.insideUnitCircle * Random.Range(0, 3); // Random bir cember alani icinden bize bir pozisyon veriyor. RASGELE KOVA CIKARMA
            Invoke("KovayiOrtayaCikart", .5f);
        }
    }

    void KovayiOrtayaCikart()
    {
        // Kova.transform.position = point;    RASGELE KOVA CIKARMA

        RandomKovaPointIndex = Random.Range(0, KovaNoktalari.Length - 1);
        Kova.transform.position = KovaNoktalari[RandomKovaPointIndex].transform.position;
        Kova.SetActive(true);
    }
}
