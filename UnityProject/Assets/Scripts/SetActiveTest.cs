using System.Collections.Generic;
using UnityEngine;

public sealed class SetActiveTest : MonoBehaviour
{
    [SerializeField] private GameObject m_gameObject;
    [SerializeField] private Transform  m_parent;
    [SerializeField] private int        m_count;

    private readonly List<GameObject> m_list = new();

    private bool m_isActive;

    private void Awake()
    {
        for ( var i = 0; i < m_count; i++ )
        {
            var x = Random.Range( -8f, 8f );
            var y = Random.Range( -4f, 4f );

            var clone = Instantiate( m_gameObject, new Vector3( x, y ), Quaternion.identity, m_parent );

            m_list.Add( clone );
        }

        Destroy( m_gameObject );
    }

    private void Update()
    {
        for ( var i = 0; i < m_list.Count; i++ )
        {
            var gameObject = m_list[ i ];
            gameObject.SetActive( m_isActive );
        }

        m_isActive = !m_isActive;
    }
}