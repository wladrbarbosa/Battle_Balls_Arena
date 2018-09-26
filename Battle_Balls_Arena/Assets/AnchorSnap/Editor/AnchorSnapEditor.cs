﻿//Poylgon Planet - Contact. https://polygonplanet.com/contact/
//Copyright © 2016-2018 Polygon Planet. All rights reserved. https://polygonplanet.com/privacy-policy/
//This source file is subject to Unity Technologies Asset Store Terms of Service. https://unity3d.com/legal/as_terms

#pragma warning disable 0168 //Variable declared, but not used.
#pragma warning disable 0219 //Variable assigned, but not used.
#pragma warning disable 0414 //Private field assigned, but not used.
#pragma warning disable 0649 //Variable asisgned to, and will always have default value.

using UnityEditor;
using UnityEngine;

public class AnchorSnapEditor : Editor
{
    [MenuItem("Anchor Snap/parent and children", false, 0)]
    static void SnapParentAndChildrenMenuItem()
    {
        SnapAnchorsMultiple(Selection.activeGameObject);
    }

    [MenuItem("Anchor Snap/just parent", false, 0)]
    static void SnapParentMenuItem()
    {
        SnapAnchors(Selection.activeGameObject);
    }

    [MenuItem("GameObject/Anchor Snap/parent and children %[", false, 0)]
    static void SnapParentAndChildrenGameObject()
    {
        SnapAnchorsMultiple(Selection.activeGameObject);
    }

    [MenuItem("GameObject/Anchor Snap/just parent %]", false, 0)]
    static void SnapParentGameObject()
    {
        SnapAnchors(Selection.activeGameObject);
    }

    public static void SnapAnchors(GameObject g)
    {
        RectTransform recTransform = null;
        RectTransform parentTransform = null;

        if (g.transform.parent != null)
        {
            if (g.GetComponent<RectTransform>() != null)
                recTransform = g.GetComponent<RectTransform>();
            else
                return;

            if (parentTransform == null)
                parentTransform = g.transform.parent.GetComponent<RectTransform>();

            Undo.RecordObject(recTransform, "Snap Anchors");

            Vector2 offsetMin = recTransform.offsetMin;
            Vector2 offsetMax = recTransform.offsetMax;
            Vector2 anchorMin = recTransform.anchorMin;
            Vector2 anchorMax = recTransform.anchorMax;
            Vector2 parent_scale = new Vector2(parentTransform.rect.width, parentTransform.rect.height);
            recTransform.anchorMin = new Vector2(anchorMin.x + (offsetMin.x / parent_scale.x), anchorMin.y + (offsetMin.y / parent_scale.y));
            recTransform.anchorMax = new Vector2(anchorMax.x + (offsetMax.x / parent_scale.x), anchorMax.y + (offsetMax.y / parent_scale.y));
            recTransform.offsetMin = Vector2.zero;
            recTransform.offsetMax = Vector2.zero;
        }
    }

    public static void SnapAnchorsMultiple(GameObject g)
    {
        SnapAnchors(g);
        for (int i = 0; i < g.transform.childCount; i++)
            SnapAnchorsMultiple(g.transform.GetChild(i).gameObject);
    }
}