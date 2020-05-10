using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePool<T> : MonosingletonGeneric<ServicePool<T>> where T: class
{
    //list holding pooled objects.
    private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

    public virtual T GetItem()
    {
        if (pooledItems.Count > 0)
        {
            PooledItem<T> item = pooledItems.Find(i => i.IsUsed == false);
            if (item != null)
            {
                item.IsUsed = true;
                return item.Item;
            }

        }

        //Create a new item and add to pool
        return CreateNewPooledItem();
    }

    private T CreateNewPooledItem()
    {
        PooledItem<T> pooledItem = new PooledItem<T>();
        pooledItem.Item = CreateItem();
        pooledItem.IsUsed = true;
        pooledItems.Add(pooledItem);
        Debug.Log("New item added to pool: " + pooledItems.Count);
        return pooledItem.Item;
    }

    public virtual void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        pooledItem.IsUsed = false;
        Debug.Log("Returning to Pool");
        
    }

    protected virtual T CreateItem()
    {
        //This is will be ovverideen in later cases since Create methods will go here.
        return (T)null;
    }

    class PooledItem<T>
    {
        public T Item;
        public bool IsUsed;
    }
}


  