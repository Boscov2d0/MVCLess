using System;
using System.Collections.Generic;
using UnityEngine;

internal abstract class DisposableObject : IDisposable
{
    private List<IDisposable> _disposableObjects = new List<IDisposable>();
    private List<GameObject> _gameObjects = new List<GameObject>();
    
    public void AddDisposableObject (IDisposable dispObject)
    {
        _disposableObjects.Add(dispObject);
    }
    public void AddGameObject(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }
    private void DisposeDisposableObjects() 
    {
        if (_disposableObjects == null)
            return;

        foreach (IDisposable obj in _disposableObjects)
        {
            obj.Dispose();
        }

        _disposableObjects.Clear();
    }
    private void DisposeGameObjects() 
    {
        if (_gameObjects == null)
            return;

        foreach (GameObject obj in _gameObjects)
        {
            UnityEngine.Object.Destroy(obj);
        }

        _gameObjects.Clear();
    }
    public void Dispose()
    {
        DisposeDisposableObjects();
        DisposeGameObjects();
    }
    protected virtual void OnDispose() { }
}