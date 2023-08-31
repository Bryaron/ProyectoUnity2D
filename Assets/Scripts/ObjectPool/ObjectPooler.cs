using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler instance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> instancedObjects;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        instancedObjects = new List<GameObject>();
        
        // Recorre los objetos que se quiere agregar
        foreach (ObjectPoolItem item in itemsToPool) {
            // Recorre la cantidad estimada
            for (int i = 0; i < item.amountToPool; i++) {
                // Instancia el objeto en la escena
                GameObject go = Instantiate(item.objectToPool);
                // Lo deja desactivado para no ser visible
                go.SetActive(false);
                // Lo agrega a la lista de objetos instanciados
                instancedObjects.Add(go);
            }
        }
    }

    public GameObject GetPoolObject(string tag) {
        // En caso de que existan objetos en la lista disponible, los retornará desde aquí
        for (int i = 0; i < instancedObjects.Count; i++) {
            // Si el item en la posición [i] no está activo en la escena y el tag corresponde, el valor será true
            if (!instancedObjects[i].activeInHierarchy && instancedObjects[i].CompareTag(tag)) {
                // Retorna el objeto libre
                return instancedObjects[i];
            }
        }
        // En caso de que no existan objetos en la lista disponible
        foreach (ObjectPoolItem item in itemsToPool) {
            // Revisará si en la lista de objetos a instanciar existe uno con el mismo tag
            if(item.objectToPool.CompareTag(tag)) {
                // Instancia el objeto en la escena
                GameObject go = Instantiate(item.objectToPool);
                // Lo deja desactivado para no ser visible
                go.SetActive(false);
                // Lo agrega a la lista de objetos instanciados
                instancedObjects.Add(go);
                // Retorna el objeto libre
                return go;
            }
        }
        // Retorna null en caso de no encontrar por el tag
        return null;
    }
}
