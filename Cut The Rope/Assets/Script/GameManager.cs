using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem KazanmaEfekti;
    [SerializeField] private ParticleSystem KesmeEfekti;
    [SerializeField] private AudioSource KaybetmeSesi;
    [SerializeField] private Top _Top;
    [SerializeField] private GameObject[] IP_Merkezleri;
    [SerializeField] private int ToplamTopSayisi;
    [SerializeField] private int DevrilmesiGerekenObjeSayisi;
    [SerializeField] private GameObject[] Canvaslar;
    

    private void Start()
    {
        KazanmaEfekti.Stop();
        KesmeEfekti.Stop();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

            if (hit.collider != null) {

                if (hit.collider.CompareTag("Merkez_1"))
                {
                    ZincirTeknikIslem(hit, "Merkez_1");           
                }
                else if (hit.collider.CompareTag("Merkez_2"))
                {
                    ZincirTeknikIslem(hit, "Merkez_2");
                }
                else if (hit.collider.CompareTag("Merkez_3"))
                {
                    ZincirTeknikIslem(hit, "Merkez_3");
                }
                else if (hit.collider.CompareTag("Merkez_4"))
                {
                    ZincirTeknikIslem(hit, "Merkez_4");
                }
            }
        }
    }
    void ZincirTeknikIslem(RaycastHit2D hit, string HingeAdi)
    {
        KesmeEfekti.transform.position = hit.collider.transform.position;
        KesmeEfekti.Play();
        KesmeEfekti.GetComponent<AudioSource>().Play();
        hit.collider.gameObject.SetActive(false);

        // _Top.HingeControl["Merkez_1"].enabled = false;

        foreach (var item in IP_Merkezleri)
        {
            if (item.GetComponent<Ip_Yonetimi>().HingeAdi == HingeAdi)
            {
               
                foreach (var item2 in item.GetComponent<Ip_Yonetimi>().BaglantiHavuzu)
                {
                    item2.SetActive(false);
                }
            }
        }
    }

    public void TopDustu()
    {
        ToplamTopSayisi--;
        if(ToplamTopSayisi == 0)
        {
            if (DevrilmesiGerekenObjeSayisi > 0)
            {
                Canvaslar[1].SetActive(true);
                KaybetmeSesi.Play();
                Debug.Log("KAYBETTIN");
            }

            else if (DevrilmesiGerekenObjeSayisi <= 0)
            {
                Canvaslar[0].SetActive(true);
                KazanmaEfekti.Play() ;
                KazanmaEfekti.GetComponent<AudioSource>().Play();
                Debug.Log("KAZANDIN");

            }
        }
        else
        {
            if (DevrilmesiGerekenObjeSayisi <= 0)
            {

                Canvaslar[0].SetActive(true);
                KazanmaEfekti.Play();
                KazanmaEfekti.GetComponent<AudioSource>().Play();
                Debug.Log("KAZANDIN");
            }
        }
    }

    public void HedefObjeDustu()
    {
        DevrilmesiGerekenObjeSayisi--;
        if (ToplamTopSayisi == 0 && DevrilmesiGerekenObjeSayisi<=0)
        {

            Canvaslar[0].SetActive(true);
            KazanmaEfekti.Play();
            KazanmaEfekti.GetComponent<AudioSource>().Play();
            Debug.Log("KAZANDIN");

        }
        else if (ToplamTopSayisi == 0 && DevrilmesiGerekenObjeSayisi > 0)
        {

            Canvaslar[1].SetActive(true);
            KaybetmeSesi.Play();
            Debug.Log("KAYBETTIN");

        }
    }

    public void SiradakiSeviyeyeGec(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void SeviyeyiTekrarla(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void DurdurmaButonu()
    {
        if (!Canvaslar[2].activeSelf)
        {
            Canvaslar[2].SetActive(true);
        }
        else
        {
            Canvaslar[2].SetActive(false);
        }
    }
}
