using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : UnitySinglegon<PipelineManager>
{
    public GameObject template;
    private List<GameObject> templates = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        template = Resources.Load<GameObject>("Prefebs/"+"pipeline");
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
        for (int i = 0; i < templates.Count; i++)
        {
            Destroy(templates[i]);
        }
        templates.Clear();
    }

    IEnumerator GeneratePipelines()
    {
        for(int i=0;i<2;i++)
        {
            GeneratePipeline();
            yield return new WaitForSeconds(3f);
        }
    }

    void GeneratePipeline()
    {
        if (templates.Count<2)
        {
            GameObject tem = Instantiate(template, this.gameObject.transform);
            GameTool.AddComponent<Pipeline>(template);
            templates.Add(tem);
        }  
    }
}
