﻿using System;
using System.Collections.Generic;
using UnityEngine;



public abstract class BaseUI : MonoBehaviour
{
    public UIEnum uiEnum { get; set; }
    public UINode uiNode { get; set; }
    protected Transform cacheTrans;
    public Transform CacheTrans
    {
        get
        {
            if (this.cacheTrans == null)
            {
                this.cacheTrans = this.transform;
            }
            return this.cacheTrans;
        }
    }
    protected GameObject cacheObj;
    public GameObject CacheObj
    {
        get
        {
            if (this.cacheObj == null)
            {
                this.cacheObj = this.gameObject;
            }
            return this.cacheObj;
        }
    }
    protected RectTransform cacheRect;
    public RectTransform CacheRect
    {
        get
        {
            if (this.cacheRect == null)
            {
                this.cacheRect = this.gameObject.GetComponent<RectTransform>();
            }
            return this.cacheRect;
        }
    }
    protected BaseData data = null;
    protected bool isInit = false;

    public abstract void resetUIInfo();
    public BaseUI()
    {
        resetUIInfo();
    }

    private void Awake()
    {
        onAwake();
    }
    public virtual void onAwake()
    {

    }

    private void Start()
    {
        if (this.uiNode != UINode.none)
        {
            this.CacheTrans.SetParent(UIMgr.Instance.getCanvasTrans(this.uiNode));
            this.CacheTrans.localPosition = new Vector3(0, 0, 0);
            this.CacheTrans.localEulerAngles = new Vector3(0, 0, 0);
            this.CacheTrans.localScale = new Vector3(1, 1, 1);
        }
        onStart();
        if (this.data != null)
        {
            refreshUI();
        }
        isInit = true;
    }
    public virtual void onStart()
    {

    }

    public virtual void setData(BaseData data)
    {
        this.data = data;
        if (isInit)
        {
            refreshUI();
        }
    }
    public virtual void setActive(bool b)
    {
        this.cacheObj.SetActive(b);
    }
    //处理UI刷新问题
    public virtual void refreshUI()
    {

    }

    //释放
    private void OnDestroy()
    {
        onDispose();
    }
    public virtual void onDispose()
    {

    }

    //
    void OnEnable()
    {
        onActive();
    }
    public virtual void onActive()
    {

    }
    void OnDisable()
    {
        onDeActive();
    }
    public virtual void onDeActive()
    {

    }

}
