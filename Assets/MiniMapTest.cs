using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{


    public class MiniMapTest : MonoBehaviour
    {
        public static void Load()
        {
            f = System.IO.File.Open(@"H:\DEV\2018\UnitySubntest\modtest.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            sw = new System.IO.StreamWriter(f);
            sw.WriteLine("ModStart");
            sw.Flush();

            sw.WriteLine("MiniMap Load");
            sw.Flush();
            var inst = new GameObject("SubnauticaMiniMap.MiniMap").AddComponent<MiniMapTest>().gameObject;
            printOnce("MiniMap instantiated");
            try
            {
                objs.Add(inst);
                printOnce("MiniMap inst added");
                GameObject obj = new GameObject("SubnauticaMiniMap.Overlay");
                obj.AddComponent<UIOverlayTest>();
                printOnce("Overlay instantiated");
                objs.Add(obj);
                inst.GetComponent<MiniMapTest>().overlay = obj;
                printOnce("Overlay instance assigned");
            }
            catch (Exception e)
            {
                printOnce(e.Message);
            }
        }

        private void Awake()
        {
            MiniMapTest.sw.WriteLine("MiniMap Awake");
            MiniMapTest.sw.Flush();
            MiniMapTest.Instance = this;
        }

        public void Update()
        {

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Pressed secondary button.");
                printOnce("update called");
                if (!initialized)
                {
                    printOnce("initialized oxygen bar");
                    var canv = GameObject.Find("Canvas");
                    if (canv == null) return;

                    printOnce("initializedCANVAS");
                    if (overlay != null)
                    {
                        try
                        {
                            printOnce("getting transform");
                            var transf = overlay.GetComponent<Transform>();
                            if (transf == null) return;
                            printOnce("transform got");
                            var canvTrans = canv.GetComponent<Transform>();
                            if (canvTrans == null) return;
                            printOnce("canv transform got");


                            GameObject obj2 = new GameObject("SubnauticaMiniMap.Overlay2");
                            GameObject obj3 = new GameObject("SubnauticaMiniMap.Overlay3");
                            var img2 = obj2.AddComponent<UnityEngine.UI.RawImage>();
                            var img3 = obj3.AddComponent<UnityEngine.UI.RawImage>();
                            img2.color = new Color(1.0f, 1.0f, 0.0f);
                            img3.color = new Color(0.0f, 1.0f, 0.0f);
                            objs.Add(obj2);
                            objs.Add(obj3);
                            var rto2 = obj2.GetComponent<RectTransform>();
                            var rto3 = obj3.GetComponent<RectTransform>();
                            //var to2 = obj2.GetComponent<Transform>();
                            //var to3 = obj3.GetComponent<Transform>();
                            //rto4.localPosition = new Vector3(2.0f,2.0f,0.0f);
                            //rto4.= new Vector3(2.0f, 2.0f, 0.0f);
                            rto3.localScale = new Vector3(0.5f, 2.5f, 1.0f);
                            rto2.localScale = new Vector3(2.0f, 0.5f, 1.0f);
                            var mcanv = canv;//mainGUI.screenCanvas;
                            if (mcanv != null)
                            {
                                var mcanv2 = mcanv.GetComponent<Transform>();
                                printOnce("c13b");
                                if (mcanv2 != null)
                                {
                                    printOnce("c13c");
                                    rto2.SetParent(mcanv2);
                                }
                            }
                            printOnce("c14");
                            rto3.SetParent(canvTrans);
                            GameObject obj4 = new GameObject("SubnauticaMiniMap.Overlay4");
                            var img4 = obj4.AddComponent<UnityEngine.UI.RawImage>();
                            img4.color = new Color(0.0f, 1.0f, 1.0f);
                            objs.Add(obj4);
                            var rto4 = obj4.GetComponent<RectTransform>();
                            rto4.localScale = new Vector3(100.0f, 100.0f, 1.0f);
                            rto4.position = new Vector3(0.0f, 0.0f, 0.0f);
                            rto4.SetParent(canvTrans);


                            transf.SetParent(canvTrans);
                            printOnce("transform set");
                            initialized = true;
                            printOnce("initialized minimap");
                        }
                        catch (Exception e)
                        {
                            printOnce("exception occured");
                            printOnce(e.Message);
                            printOnce(e.ToString());
                            printOnce(e.StackTrace);
                        }
                    }
                    else
                    {
                        printOnce("overlay was null");
                    }
                }
            }
        }

        public static void printOnce(string message)
        {
            bool is_new = printed.Add(message);
            if (is_new)
            {
                MiniMapTest.sw.WriteLine(message);
                MiniMapTest.sw.Flush();
            }
        }

        public static HashSet<string> printed = new HashSet<string>();

        private bool initialized = false;
        private UnityEngine.UI.Graphic g;

        private static List<UnityEngine.Object> objs = new List<UnityEngine.Object>();
        public GameObject overlay;

        public static MiniMapTest Instance { get; private set; }

        public static FileStream f;
        public static StreamWriter sw;

    }
}
