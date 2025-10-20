-- tb_rtn_routine
-- ROUTINE 테이블
-- 설명 : 루틴에 포함되어야 하는 정보를 나열한다.
-- 컬럼 
-- 01. ROUTINE_ID / 루틴 아이디 / int AI PK
-- 02. ROUTINE_NM / 루틴 명칭 / varchar(20)
-- 03. ROUTINE_DESC / 루틴 설명 / varchar(100)
-- 04. ROUTINE_PART / 루틴 부위 / varchar(20)
-- 05. ROUTINE_ALERT_YN / 알람여부 / varchar(1)
-- 06. ROUTINE_CREATE_ID / 생성ID / varchar(45)
-- 07. ROUTINE_CREATE_DT / 생성날짜 / datetime
-- 08. ROUTINE_UPDATE_ID / 수정ID / varchar(45)
-- 09. ROUTINE_UPDATE_DT / 수정날짜 / datetime

-- 조회 예시
SELECT * FROM TB_RTN_ROUTINE;

-- 입력 예시
INSERT INTO TB_RTN_ROUTINE
(ROUTINE_NM, ROUTINE_DESC, ROUTINE_PART, ROUTINE_ALERT_YN, ROUTINE_CREATE_ID, ROUTINE_CREATE_DT, ROUTINE_UPDATE_ID, ROUTINE_UPDATE_DT)
VALUES
('하체 루틴', '프리웨이트 중심', 'PART_003', 'N', 'KIMSANGKI', SYSDATE(), 'KIMSANGKI', SYSDATE());

 -- 삭제 예시
 DELETE FROM TB_RTN_ROUTINE WHERE ROUTINE_ID = 1;
 
 -- 수정 예시
 UPDATE TB_RTN_ROUTINE 
 SET ROUTINE_DESC = '루틴설명'
 WHERE ROUTINE_ID = 1;
 
 -- 테이블 초기화
 TRUNCATE TABLE TB_RTN_ROUTINE;