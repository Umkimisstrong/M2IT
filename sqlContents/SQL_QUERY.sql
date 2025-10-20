-- 00. TEXT VALUE
		SELECT CD, CD_NM
          FROM tb_cmm_code
		 WHERE SYS_CD = 'CMM'
           AND DIV_CD = 'BODY_PART'
	;

-- 01. ROUTINE LIST
		SELECT A.ROUTINE_ID
			 , A.ROUTINE_NM
             , A.ROUTINE_DESC
             , B.CD_NM
             , A.ROUTINE_CREATE_DT
             , A.ROUTINE_CREATE_ID
		  FROM tb_rtn_routine A
    INNER JOIN tb_cmm_code B ON A.ROUTINE_PART = B.CD AND B.SYS_CD = 'CMM' AND B.DIV_CD = 'BODY_PART'
             WHERE A.ROUTINE_CREATE_ID = 'KIMSANGKI';
        
        
        
        SELECT A.ROUTINE_ID
             , A.ROUTINE_NM
             , A.ROUTINE_PART
             , C.CD_NM
             , B.TRAINING_NM
             , B.TRAINING_CD
             , D.CD_NM
             , B.TRAINING_WEIGHT AS WEIGHT
             , B.TRAINING_REPS AS REPS
             , B.TRAINING_SET AS SETS
             , B.TRAINING_WEIGHT * B.TRAINING_REPS * B.TRAINING_SET AS TRAINING_VOLUMN
		  FROM tb_rtn_routine A
    INNER JOIN tb_rtn_training B ON A.ROUTINE_ID = B.ROUTINE_ID		
    INNER JOIN tb_cmm_code C ON A.ROUTINE_PART = C.CD AND C.SYS_CD = 'CMM' AND C.DIV_CD = 'BODY_PART'
    INNER JOIN tb_cmm_code D ON B.TRAINING_CD = D.CD AND D.SYS_CD = 'RTN_CD'
         WHERE A.ROUTINE_CREATE_ID = 'KIMSANGKI';
    