using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.Rendering;
using UnityEngine.InputSystem;



[CustomEditor(typeof(automaticAdd))]
public class RenderListEditor : Editor
{
    // ����Inspector����
    public override void OnInspectorGUI()
    {
        // ��ȡRenderListExample�ű�����
        automaticAdd renderList = (automaticAdd)target;

        // ����Ĭ��Inspector����
        DrawDefaultInspector();

        // ��ʾRender�б�
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Renderer List:");

        // ѭ������Render�б�����ÿ��Ԫ�ص�����
        for (int i = 0; i < renderList.Renderers.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Renderer " + (i + 1) + ":", GUILayout.Width(70));
            renderList.Renderers[i] = (Renderer)EditorGUILayout.ObjectField(renderList.Renderers[i], typeof(Renderer), true);

            // ���һ���µ���Ⱦ��Ԫ��
            if (GUILayout.Button("+", GUILayout.Width(20)))
            {
                renderList.Renderers.Insert(i + 1, null);
            }

            // ɾ��һ����Ⱦ��Ԫ��
            if (GUILayout.Button("-", GUILayout.Width(20)))
            {
                renderList.Renderers.RemoveAt(i);
            }

            EditorGUILayout.EndHorizontal();
        }

        // ���һ���µ���Ⱦ��Ԫ��
        if (GUILayout.Button("Add Renderer"))
        {
            renderList.Renderers.Add(null);
        }

        // ɾ��������Ⱦ��Ԫ��
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