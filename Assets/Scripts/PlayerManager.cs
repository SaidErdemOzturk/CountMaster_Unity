using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject stickManPrefab;
    [SerializeField] private GameObject stack;
    [SerializeField] private float radius, distanceFactor;
    [SerializeField] private TMPro.TextMeshPro counterText;
    [SerializeField] public float speed;
    [SerializeField] private ObjectPool objectPool;
    private List<GameObject> stickMans;
    private bool isClickButton;
    private GameObject tempObj;
    public Animator animator;
    public static PlayerManager PlayerManagerInstance;

    private void Start()
    {
        stickMans = new List<GameObject>();
        stickMans.Add(stack.transform.GetChild(0).gameObject);
        animator = GetComponent<Animator>();
        PlayerManagerInstance = this;
    }

    private void OnEnable()
    {
        ActionsManager.OnAddStick += AddStickMan;
        ActionsManager.OnRemoveStick+= RemoveStickMan;
    }

    private void OnDisable()
    {
        ActionsManager.OnAddStick -= AddStickMan;
        ActionsManager.OnRemoveStick-= RemoveStickMan;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClickButton = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClickButton = false;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward*Time.fixedDeltaTime*speed);
        if (isClickButton)
        {
            float axis = Input.GetAxis("Mouse X");
            float mouseX = axis + transform.position.x;
            mouseX = Mathf.Clamp(mouseX, -2, 2);
            transform.position = new Vector3(mouseX, transform.position.y, transform.position.z);
        }
    }

    public void MultiplyStickMan(int gatePoint)
    {
        int childCount = stickMans.Count;
        for (int i = 0; i < (childCount * gatePoint) - childCount; i++)
        {
            tempObj = objectPool.GetPooledObject(0);
            tempObj.transform.SetParent(stack.transform);
            tempObj.transform.localPosition = new Vector3(0, 0, 0);
            stickMans.Add(tempObj);
        }
    }

    public void PlusStickMan(int gatePoint)
    {
        for (int i = 0; i < gatePoint; i++)
        {
            tempObj = objectPool.GetPooledObject(0);
            tempObj.transform.SetParent(stack.transform);
            tempObj.transform.localPosition = new Vector3(0, 0, 0);
            stickMans.Add(tempObj);
        }
    }

    private void UpdateStickList()
    {
        counterText.text = stickMans.Count.ToString();
    }

    IEnumerator ChangePositionStick()
    {
        yield return new WaitForSeconds(1f);
        PositionChange();
    }

    public void PositionChange()
    {
        for (int i = 0; i < stickMans.Count; i++)
        {
            var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
            var newPos = new Vector3(x, 0, z);
            stickMans[i].transform.DOLocalMove(newPos, 1).SetEase(Ease.OutBack);
        }
    }

    private void RemoveStickMan(GameObject obj)
    {
        stickMans.Remove(obj);
        objectPool.HidePooledObject(obj);
        UpdateStickList();
        obj.transform.SetParent(null);
        StartCoroutine(ChangePositionStick());
    }

    private void AddStickMan(GateManager gateManager)
    {
        switch (gateManager.gateType)
        {
            case GateType.Plus:
                PlusStickMan(gateManager.randomNumber);
                break;
            case GateType.Multiply:
                MultiplyStickMan(gateManager.randomNumber);
                break;
            default:
                break;
        }
        if(tempObj != null)
        {
            tempObj.AddComponent<StackObjectController>();
            UpdateStickList();
        }
        PositionChange();
    }
}
