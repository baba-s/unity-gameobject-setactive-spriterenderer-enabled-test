using System.Collections.Generic;
using UnityEngine;

public sealed class EnabledTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private Transform      m_parent;
    [SerializeField] private int            m_count;

    private readonly List<SpriteRenderer> m_list = new();

    private bool m_enabled;

    private void Awake()
    {
        for ( var i = 0; i < m_count; i++ )
        {
            var x = Random.Range( -8f, 8f );
            var y = Random.Range( -4f, 4f );

            var clone = Instantiate( m_spriteRenderer, new Vector3( x, y ), Quaternion.identity, m_parent );

            m_list.Add( clone );
        }

        Destroy( m_spriteRenderer );
    }

    private void Update()
    {
        for ( var i = 0; i < m_list.Count; i++ )
        {
            var spriteRenderer = m_list[ i ];
            spriteRenderer.enabled = m_enabled;
        }

        m_enabled = !m_enabled;
    }
}