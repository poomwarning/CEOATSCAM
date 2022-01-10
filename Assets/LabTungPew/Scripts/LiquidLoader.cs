using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidLoader : MonoBehaviour
{
    public LiquidObj liquid;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TungPew()
    {
        StartCoroutine(SmoothBlendShape(0, 20, 2));
    }
    public void NormalPew()
    {
        StartCoroutine(SmoothBlendShape(20, 0, 1));
    }
    private IEnumerator SmoothBlendShape(float start, float end, float duration)
    {
        float value = 0;
        float time = 0;
        while (time <= duration)
        {
            time = time + Time.deltaTime;
            value = Mathf.Lerp(start, end, time / duration);
            skinnedMeshRenderer.SetBlendShapeWeight(0, value);
            yield return null;
        }
    }
}
