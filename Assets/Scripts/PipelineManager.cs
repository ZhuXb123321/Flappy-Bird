using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour
{
    public GameObject template;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine = null;

    public void StartRun()
    {
        coroutine=StartCoroutine(GeneratePipelines());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator GeneratePipelines()
    {
        while (true)
        {
            GeneratePipeline();

            yield return new WaitForSeconds(2f);
        }
    }

    void GeneratePipeline()
    {
        Instantiate(template,this.gameObject.transform);
    }
}
