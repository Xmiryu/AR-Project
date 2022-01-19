using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

using System.Linq;
using UnityEditor;
using System.Reflection;

public class FetchTexture : MonoBehaviour
{
    [SerializeField] [OnChangedCall("onSerializedPropertyChange")] public string image_url = "https://assets.cdn.ifixit.com/static/images/avatars/User/ifixit/avatar-2.200x150";

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
            Renderer m_Renderer = GetComponent<Renderer>();

            //Make sure to enable the Keywords
            m_Renderer.material.EnableKeyword("_NORMALMAP");
            m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");

            m_Renderer.material.SetTexture("_MainTex", texture);
        }
    }

    public void changeImageURL(string newURL)
    {
        image_url = newURL;
        StartCoroutine(GetTexture());
    }

    public void onSerializedPropertyChange()
    {
        Debug.Log("Image changed to: " + image_url);
        StartCoroutine(GetTexture());
    }

    void Start()
    {
        StartCoroutine(GetTexture());
    }
}



//https://stackoverflow.com/questions/63778384/unity-how-to-update-an-object-when-a-serialized-field-is-changed
public class OnChangedCallAttribute : PropertyAttribute
{
    public string methodName;
    public OnChangedCallAttribute(string methodNameNoArguments)
    {
        methodName = methodNameNoArguments;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(OnChangedCallAttribute))]
public class OnChangedCallAttributePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property);
        if (EditorGUI.EndChangeCheck())
        {
            OnChangedCallAttribute at = attribute as OnChangedCallAttribute;
            MethodInfo method = property.serializedObject.targetObject.GetType().GetMethods().Where(m => m.Name == at.methodName).First();

            if (method != null && method.GetParameters().Count() == 0)// Only instantiate methods with 0 parameters
                method.Invoke(property.serializedObject.targetObject, null);
        }
    }
}
#endif