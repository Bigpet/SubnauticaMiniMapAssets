using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTester : MonoBehaviour {

    public static float mapScale = 0.4f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var mapimg = GameObject.Find("MapImage");
        var player = PlayerController.player;
        if (mapimg && player)
        {
            var transf = mapimg.GetComponent<RectTransform>();
            var angles = player.transform.rotation.eulerAngles;
            //transf.rotation.SetAxisAngle(new Vector3(0.0f,0.0f,1.0f), angles.magnitude);
            //-Player.main.camRoot.transform.rotation.eulerAngles.y

            //transf.rotation = Quaternion.AngleAxis(-Player.main.camRoot.transform.rotation.eulerAngles.y + ((int)rotated)* variableRot), new Vector3(0.0f, 0.0f, 1.0f));

            //transf.localRotation = Quaternion.AngleAxis(-player.transform.rotation.eulerAngles.y, new Vector3(0.0f, 0.0f, 1.0f));
            transf.rotation = Quaternion.identity;
            transf.position = Vector3.zero;
            transf.localRotation = Quaternion.identity;
            transf.localPosition = Vector3.zero;

            //    Quaternion.AngleAxis(-player.transform.rotation.eulerAngles.y, new Vector3(0.0f, 0.0f, 1.0f));

            //transf.localPosition.Scale(new Vector3(0.0f, 1.0f, 0.0f));
            transf.Rotate(0.0f, 0.0f, -player.transform.rotation.eulerAngles.y);
            transf.Translate(
                player.transform.position.x * -1.0f / mapScale,
                player.transform.position.z * -1.0f / mapScale,
                0.0f
                );
            //transf.Translate(
            //    player.transform.position.x * 2.0f / mapScale,
            //    player.transform.position.z * 2.0f / mapScale,
            //    0.0f
            //    );

            //transf.localPosition = new Vector3(
            //    player.transform.position.x * 1.0f / mapScale,
            //    player.transform.position.z * 1.0f / mapScale,
            //    0.0f
            //    );
            ////transf.localPosition.y = Player.main.transform.position.y * 1.0f / mapScale;
        }

    }
}
