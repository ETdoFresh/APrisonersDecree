using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEventOriginal = UnityEngine.Events.UnityEvent;

[Serializable] public class UnityEvent : UnityEventOriginal { }
[Serializable] public class UnityEventGameObject : UnityEvent<GameObject> { }
[Serializable] public class UnityEventTransform : UnityEvent<Transform> { }
[Serializable] public class UnityEventPointerEventData : UnityEvent<PointerEventData> { }
