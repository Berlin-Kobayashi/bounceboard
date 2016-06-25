using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SVGImporter;

public class SVGContainer : MonoBehaviour
{
    public SVGAsset[] svgAssets;

    private IDictionary<string, SVGAsset> svgAssetsMap;

    void Start()
    {
        svgAssetsMap = new Dictionary<string, SVGAsset>();

        for (int i = 0; i < svgAssets.Length; i++)
        {
            SVGAsset currentAsset = svgAssets[i];
            svgAssetsMap.Add(currentAsset.name,currentAsset);
        }
        foreach (KeyValuePair<string, SVGAsset> kvp in svgAssetsMap)
        {
            //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
           Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }

    }

    public SVGAsset getSvg(string name)
    {
        return svgAssetsMap[name];
    }
}
