
## This README.txt explains how Skill class works.

-SkillData : 스킬의 기본값들을 table에 저장하는 값들, ScriptableObject로 정의했고, Assets/Resources/SkillData/ 안에 생성해야함. 사용 방법은 우클릭->create->생성
-ActiveSkill : 기존의 Skill.cs 와는 다름. 추상 클래스이며, 생성자로 SkillData의 값들을 받아서 초기화함. 다른 상세 스킬에게 상속하기 위한 추상 클래스이지만, 
type을 ActiveSkill로 지정해도 무방함 

	attribute : skillData에서 지정받는것들, 
	method : 추상 method인 castSkill 2개. 대상지정 스킬과 아닌 스킬을 구분하기 위해 함수 오버로딩을 함. 하나는 인자가 GameObject이고 하나는 인자가 Vector3Int임.
			 returnSkillDanage : float // TODO : 스킬 데미지를 구현하는 메소드, 아직 구현 안함
			 showRange : void // TODO : 마우스 기준 스킬 범위를 구현하는 메소드, 아직 구현 안함.

-ActiveSkillList : ActiveSkill을 상속받은 구체 스킬 (MagicBullet) 같은 클래스들을 모아둔 file. castSkill 2개에 대한 overriding을 해야 함.

-skillSystem :  player의 스킬 사용을 관리하는 class. SkillManager 의 component
				플레이어의 스킬 할당, 스킬 범위 원, 마우스 범위 체크 등을 하며
				ActiveSkill에 있는 method를 대부분 호출함.

-skillInstances : ActiveSkillList의 skill들을, 게임 시작 시 인스턴스화 해야하기 때문에 사용하는 메소드. 역시 SkillManager의 component로 넣어야 함.


나중에 해야 할 것 : SkillData를 직접 만든다 / table에서 값을 가져와서 동적으로 할당해준다. 둘 중에 하나 선택