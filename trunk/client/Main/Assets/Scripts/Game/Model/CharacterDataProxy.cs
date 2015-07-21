using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDataProxy
{
    public enum FieldID : uint
    {
        OPERATOR    = 0x1111,
        CLASS       = 0x0001,
        SEX         = 0x0010,
        NICKNAME    = 0x0100,
    }

    private List<FieldID> m_modifiedIDs = new List<FieldID>();

    /// <summary>
    /// 职业
    /// </summary>
    private int m_class = 0;
    public int Class
    {
        set
        {
            m_class = value;
            m_modifiedIDs.Add(FieldID.CLASS);
        }
        get { return m_class; }
    }

    /// <summary>
    /// 性别
    /// </summary>
    private byte m_sex = 0;
    public byte Sex
    {
        set
        {
            m_sex = value;
            m_modifiedIDs.Add(FieldID.SEX);
        }
        get { return m_sex; }
    }

    /// <summary>
    /// 昵称
    /// </summary>
    // private string m_nickname = 0;

    public void NotifyModification()
    {
        uint opt = (uint)FieldID.OPERATOR;
        for (int i = 0; i < m_modifiedIDs.Count; ++i)
        {
            opt &= (uint)m_modifiedIDs[i];
        }
        m_modifiedIDs.Clear();
        SendEvent(opt);
    }
}
