
## This README.txt explains how Skill class works.

-SkillData : ��ų�� �⺻������ table�� �����ϴ� ����, ScriptableObject�� �����߰�, Assets/Resources/SkillData/ �ȿ� �����ؾ���. ��� ����� ��Ŭ��->create->����
-ActiveSkill : ������ Skill.cs �ʹ� �ٸ�. �߻� Ŭ�����̸�, �����ڷ� SkillData�� ������ �޾Ƽ� �ʱ�ȭ��. �ٸ� �� ��ų���� ����ϱ� ���� �߻� Ŭ����������, 
type�� ActiveSkill�� �����ص� ������ 

	attribute : skillData���� �����޴°͵�, 
	method : �߻� method�� castSkill 2��. ������� ��ų�� �ƴ� ��ų�� �����ϱ� ���� �Լ� �����ε��� ��. �ϳ��� ���ڰ� GameObject�̰� �ϳ��� ���ڰ� Vector3Int��.
			 returnSkillDanage : float // TODO : ��ų �������� �����ϴ� �޼ҵ�, ���� ���� ����
			 showRange : void // TODO : ���콺 ���� ��ų ������ �����ϴ� �޼ҵ�, ���� ���� ����.

-ActiveSkillList : ActiveSkill�� ��ӹ��� ��ü ��ų (MagicBullet) ���� Ŭ�������� ��Ƶ� file. castSkill 2���� ���� overriding�� �ؾ� ��.

-skillSystem :  player�� ��ų ����� �����ϴ� class. SkillManager �� component
				�÷��̾��� ��ų �Ҵ�, ��ų ���� ��, ���콺 ���� üũ ���� �ϸ�
				ActiveSkill�� �ִ� method�� ��κ� ȣ����.

-skillInstances : ActiveSkillList�� skill����, ���� ���� �� �ν��Ͻ�ȭ �ؾ��ϱ� ������ ����ϴ� �޼ҵ�. ���� SkillManager�� component�� �־�� ��.


���߿� �ؾ� �� �� : SkillData�� ���� ����� / table���� ���� �����ͼ� �������� �Ҵ����ش�. �� �߿� �ϳ� ����