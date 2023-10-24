using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TopAtar _TopAtar;
    [SerializeField] private CizgiCiz _CizgiCiz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DevamEt()
    {
        _TopAtar.DevamEt();
        _CizgiCiz.DevamEt();

    }

    public void OyunBitti()
    {
        Debug.Log("KAYBETTIN");
    }
}
