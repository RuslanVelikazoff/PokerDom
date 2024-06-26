using System.Collections.Generic;
using UnityEngine;

public class TaskScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject taskPrefab;

    [SerializeField] 
    private Canvas canvas;

    private List<GameObject> tasks = new List<GameObject>();
    private List<int> taskIndex;

    private void OnEnable()
    {
        ResetAllTasks();
        SpawnPrefabsIntScrollView();
    }

    private void SpawnPrefabsIntScrollView()
    {
        taskIndex = TaskData.Instance.GetTaskIndexList();

        for (int i = 0; i < taskIndex.Count; i++)
        {
            var task = Instantiate(taskPrefab, transform.position, Quaternion.identity);
            task.transform.SetParent(canvas.transform);
            task.transform.localScale = new Vector3(1, 1, 1);
            task.transform.SetParent(this.gameObject.transform);
            task.GetComponent<TaskPrefab>().SpawnPrefab(taskIndex[i]);
            tasks.Add(task);
        }
    }

    private void ResetAllTasks()
    {
        if (tasks != null)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Destroy(tasks[i]);
                tasks.RemoveAt(i);
                ResetAllTasks();
            }
        }
    }
}
