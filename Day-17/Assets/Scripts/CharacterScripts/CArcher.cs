using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Stat : Chr_Stat
{
    public int m_AttackLength;
  

    public Archer_Stat(string a_CrName = "", int a_AttackLength = 100)
    {
        m_CharType = CharicType.Archer;
        m_StrJob = "궁수";
        m_RscFile = "Images/ArcRanderer";
        m_Name = a_CrName;
        m_MaxHp = 150;
        m_MaxMana = 80;
        m_Attack = 50;
        m_AttackLength = a_AttackLength;
        
    }

    //캐릭터의 스탯 정보를 기반으로 지형에 돌아다니는 캐릭터 객체를 추가하려고 할 때
    //Hero 게임 오브젝트에 빙의 시키킬 원하는 클래스 추가 함수
    public override CUnit MyAddComponent(GameObject a_ParentGObj)
    {
        //매개변수로 받은 Hero GameObject 에 CWizard 컴포넌트를 붙여 주고
        CUnit a_RefHero = a_ParentGObj.AddComponent<CArcher>();
        a_RefHero.m_ChrStat = this;   //지금 이 Wizard_Stat 객체를 CWizard : CUnit쪽 m_ChrStat 변수에 대입해 준다.
        return a_RefHero;
    }
    public class CArcher : CUnit
    {
        //1.awake - 2 myaddcomponent : arefhero.mchrstat = this; =--- 3 start()


        //void Awake()  //override 안하면 이것만 호출된다.
        //{
        //}

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start(); //부모쪽 Start() 함수 호출 (공통 등장 준비) 

            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"{m_ChrStat.m_Name} : 아처 고유 등장 준비");
        }

        // Update is called once per frame
        protected override void Update()
        {
            //아처의 고유 AI 행동 패턴 코드
        }

        public override void Attack()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"아처 공격 : 이름({m_ChrStat.m_Name}), Hp({m_CurHp}) 공격력({m_CurAtt})");
        }

        public override void UseSkill()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"아처 스킬 : 이름({m_ChrStat.m_Name}), " +
                                    $"사거리({((Archer_Stat)m_ChrStat).m_AttackLength})");
                                
        }


    }
}
