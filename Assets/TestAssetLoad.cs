using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestAssetLoad : MonoBehaviour
{
    private void LoadAssets()
    {
        this.materialMapColored = this.assets.LoadAsset<Material>("MapColored");
        Debug.Log(materialMapColored);
        this.world = this.assets.LoadAsset<Texture2D>("world_base");
        //GetComponent<Renderer>().material = this.materialMapColored;
        GetComponent<Renderer>().material.SetTexture("_MainTex", this.world);
        var materialFogdecal = this.assets.LoadAsset<Material>("Fogdecal");
        var prefabMapSwitcher = this.assets.LoadAsset<GameObject>("MapSwitcher");
        var prefabMapSwitchPanel = this.assets.LoadAsset<GameObject>("MapSwitchPanel");
        var prefabMapSwitchItem = this.assets.LoadAsset<GameObject>("MapSwitchItem");
        var prefabCoord = this.assets.LoadAsset<GameObject>("Coord");
        var prefabToogleMap = this.assets.LoadAsset<GameObject>("ToggleMap");
        var prefabMapContainer = this.assets.LoadAsset<GameObject>("MapContainer");
        var prefabScanPanel = this.assets.LoadAsset<GameObject>("ScanPanel");
        var prefabScanPanelItem = this.assets.LoadAsset<GameObject>("ScanPanelItem");
        var allSprites = this.assets.LoadAllAssets<Sprite>();
        var brush = this.assets.LoadAsset<Texture2D>("brush");
    }


    private void LoadAssetBundle()
    {
        Debug.Log("loading assets");
        this.assets = (from x in Resources.FindObjectsOfTypeAll<AssetBundle>()
                       where x.name == "subnauticamap"
                       select x).FirstOrDefault<AssetBundle>();
        if (this.assets == null)
        {
            Debug.Log("Trying to open file: ");
            var file = System.IO.Path.Combine("H:\\SteamLibrary\\steamapps\\common\\Subnautica\\QMods\\SubnauticaMap", "subnauticamap");
            Debug.Log(file);
            this.assets = AssetBundle.LoadFromFile(file);
            Debug.Log(this.assets.GetAllAssetNames().Length);
            foreach(string s in this.assets.GetAllAssetNames())
            {
                Debug.Log(s);
            }
        }
        if (this.assets == null)
        {
            Debug.Log("Failed to load assets");
            //Logger.Write("Failed to load assets");
        }
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("starting");
        //LoadAssetBundle();
        //LoadAssets();
        Debug.Log("started");

        var obj = GameObject.Find("Panel");
        var canvas = GameObject.Find("Canvas");
        if (obj == null)
        {
            Debug.Log("panel was null");
        }
        else if(canvas == null)
        {
            Debug.Log("canvas was null");
        }
        else
        {
            Debug.Log("trying to change canvas");
            var c = canvas.GetComponent<Transform>();

            obj.GetComponent<Transform>().SetParent(c);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private AssetBundle assets;
    private Material materialMapColored;
    private Texture2D world;
}
