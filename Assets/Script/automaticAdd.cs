using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.Rendering;
using UnityEngine.InputSystem;



[CustomEditor(typeof(automaticAdd))]
public class RenderListEditor : Editor
{
    // 绘制Inspector界面
    public override void OnInspectorGUI()
    {
        // 获取RenderListExample脚本对象
        automaticAdd renderList = (automaticAdd)target;

        // 绘制默认Inspector界面
        DrawDefaultInspector();

        // 显示Render列表
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Renderer List:");

        // 循环遍历Render列表并绘制每个元素的属性
        for (int i = 0; i < renderList.Renderers.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Renderer " + (i + 1) + ":", GUILayout.Width(70));
            renderList.Renderers[i] = (Renderer)EditorGUILayout.ObjectField(renderList.Renderers[i], typeof(Renderer), true);

            // 添加一个新的渲染器元素
            if (GUILayout.Button("+", GUILayout.Width(20)))
            {
                renderList.Renderers.Insert(i + 1, null);
            }

            // 删除一个渲染器元素
            if (GUILayout.Button("-", GUILayout.Width(20)))
            {
                renderList.Renderers.RemoveAt(i);
            }

            EditorGUILayout.EndHorizontal();
        }

        // 添加一个新的渲染器元素
        if (GUILayout.Button("Add Renderer"))
        {
            renderList.Renderers.Add(null);
        }

        // 删除所有渲染器元素
        if (GUILayout.Button("Clear Renderers"))
        {
            renderList.Renderers.Clear();
        }
    }
}


public class automaticAdd : MonoBehaviour
{
    private Renderer[] renderers;
    private List<Renderer> RendererList = new List<Renderer>();
   
    public void Add()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in renderers)
        {
            if (!RendererList.Contains(renderer))
            {
                RendererList.Add(renderer);
            }
        }

    }
    public List<Renderer> Renderers 
    { 
        get { return RendererList; } 
    }

   
}