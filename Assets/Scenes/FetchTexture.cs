using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
 
public class FetchTexture : MonoBehaviour
{

    public Texture texture = null;
    void Start()
    {
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://assets.cdn.ifixit.com/static/images/avatars/User/ifixit/avatar-2.200x150");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.position = new Vector3(0, 1.5f, 0);
            //sphere.renderer.material.mainTexture = tex;
        }
    }
}