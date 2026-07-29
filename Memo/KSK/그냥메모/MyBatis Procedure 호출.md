

1. 저장프로시저 생성
```
	 CREATE OR REPLACE PROCEDURE HAMISDBA.프로시저명
	 (
	     P_RCPT_NO        IN VARCHAR2
	   , REG_SRVC_ID      IN VARCHAR2
	   , REG_SCRN_ID      IN VARCHAR2
	   , FRST_KBRDR_EMPNO IN VARCHAR2
	 )
	 IS
	 BEGIN
	      -- 1번째 실행 쿼리
	      INSERT INTO ...
	      SELECT *
	        FROM TABLE;
	        
	      -- 2번째 실행 쿼리
	      UPDATE ...
	         SET
	       WHERE RCPT_NO = P_RCPT_NO;
	 END;
	 
	 -- EXCUTE 권한 할당 (HAMISDBA - PL)
	 GRANT EXECUTE ON 프로시저명 TO HAMISMAN;
	 
	 -- SYNONYM 생성 (HISDBA - PL)
	 CREATE PUBLIC SYNONYM 프로시저명 FOR HAMISDBA.프로시저명;
	  
```
2.  저장프로시저 DB 실행
	```
		BEGIN
		    HAMISDBA.프로시저명(
		        '011313343',
		        'SRVC',
		        'SCRN',
		        'HAMIS06',
		    );
		END;
	```
3. DTO 생성 (프로시저 파라미터 타입에 맞게 정의)
	```
		public class TestDTO extends AbstractDTO()
		{
		    private String pRcptNo;
		    ...
		}
	```   
4.  Mapper 생성

```
	[Mapper.Java]
	int callPregInspProc(RetrieveRcptNoDTO dto);
	
	[Mapper.xml]
	<update id="callPregInspProc"
            parameterType="kr.co.hanaro.hamis.hm.gr.rv.entity.RetrieveRcptNoDTO"
            statementType="CALLABLE">
			{CALL HAMISDBA.프로시저명(
				#{pRcptNo, mode=IN, jdbcType=VARCHAR},
				#{regSrvcId, mode=IN, jdbcType=VARCHAR},
				#{regScrnId, mode=IN, jdbcType=VARCHAR},
				#{frstKbrdrEmpno, mode=IN, jdbcType=VARCHAR},
	)}
	</update>
```

