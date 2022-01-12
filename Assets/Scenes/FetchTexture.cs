using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
 
public class FetchTexture : MonoBehaviour
{
    [SerializeField] public string image_url = "https://assets.cdn.ifixit.com/static/images/avatars/User/ifixit/avatar-2.200x150";

    private Renderer m_Renderer;
    private Texture texture = null;

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(image_url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            texture = ((DownloadHandlerTexture)www.downloadHandler).texture;


            //Fetch the Renderer from the GameObject
            m_Renderer = GetComponent<Renderer>();

            //Make sure to enable the Keywords
            m_Renderer.material.EnableKeyword("_NORMALMAP");
            m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");

            //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
            m_Renderer.material.SetTexture("_MainTex", texture);

            //Set the Normal map using the Texture you assign in the Inspector
            //m_Renderer.material.SetTexture("_BumpMap", m_Normal);
            //Set the Metallic Texture as a Texture you assign in the Inspector
            //m_Renderer.material.SetTexture("_MetallicGlossMap", m_Metal);

            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.position = new Vector3(0, 1.5f, 0);
            //sphere.renderer.material.mainTexture = tex;
        }
    }

    void Start()
    {
        StartCoroutine(GetTexture());
    }
}