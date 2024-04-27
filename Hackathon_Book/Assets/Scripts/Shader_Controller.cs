using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Shader_Controller : MonoBehaviour
{
    public GameObject _del;
    //sheder-block-------------
    public MeshRenderer skinnedMesh;
    public Material[] skinnedMaterials;

    public VisualEffect VFXGraph;
        
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;   
    //--------------------------
    // Start is called before the first frame update

    public Perehod _SC_good;
    public Book_Vision_Mechanica _SC_you_can;
    public bool is_done;
    public float time;

    void Start()
    {
        is_done = false;
        skinnedMesh =GetComponent<MeshRenderer>();
        skinnedMaterials[0].SetFloat("_DissolveAmot", 0f);
        //sf (skinnedMesh == null){skinnedMaterials[i] = skinnedMesh[i].materials;}
    }

    // Update is called once per frame
    void Update()
    {
        if(_SC_good._is_good == true){
            _SC_you_can.you_can = false;
            StartCoroutine(DissolveCo());
            _SC_good._is_good = false;
            
            
        }
    }
    IEnumerator DissolveCo()
    {
        skinnedMaterials[0].SetFloat("_DissolveAmot", 0f);
        if(VFXGraph != null)
        {
            VFXGraph.Play();
        }
        Debug.Log(skinnedMaterials[0]);
        if(skinnedMaterials.Length > 0)
        {
            float counter = 0;
            while(skinnedMaterials[0].GetFloat("_DissolveAmot") < 1)
            {
                counter += dissolveRate;
                
                    skinnedMaterials[0].SetFloat("_DissolveAmot", counter);
                
                yield return new WaitForSeconds(refreshRate);
                //Debug.Log(counter);
                if(counter >= 1f)
                {
                    Debug.Log("Test");
                    skinnedMaterials[0].SetFloat("_DissolveAmot", 0f);
                    _SC_you_can.you_can = true;
                    is_done = false;
                    _del.SetActive(false);
                }
            }
            
        }
    }
}
//skinnedMaterials[0].GetFloat("DissolveAmot") < 1