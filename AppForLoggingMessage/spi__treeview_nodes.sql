CREATE PROCEDURE [dbo].[spi__treeview_nodes]
(@i_trans_id	BIGINT
)
AS
BEGIN

  -- Errors

  -- Constants
  DECLARE @c_return_code_NO_ERRORS                                      INT;						 SET @c_return_code_NO_ERRORS = 0;
  DECLARE @c_return_code_ERROR                                          INT;						 SET @c_return_code_ERROR = 1;
  DECLARE @c_return_code_UNEXPECTED_ERROR                               INT;						 SET @c_return_code_UNEXPECTED_ERROR = 9;
  DECLARE @c_message_type_ERROR                                         NVARCHAR(1);		 SET @c_message_type_ERROR = 'E';

	-- Variables
  DECLARE @v_return_code                                                INT;             SET @v_return_code = @c_return_code_UNEXPECTED_ERROR;
  DECLARE @v_local_return_code                                          INT;             SET @v_local_return_code = @c_return_code_UNEXPECTED_ERROR;
  DECLARE @v_log_info                                                   NVARCHAR(MAX);   SET @v_log_info = ''; 
	
  ---------- Logging ----------
  SELECT @v_log_info = SUBSTRING(REPLACE(
    'Procedure dbo.spi__treeview_nodes' +
		' <@i_trans_id = '																 +        RTRIM(COALESCE(CAST(@i_trans_id AS NVARCHAR(250)), 'NULL')) +
				'>', '''<null>''', 'NULL'), 1, 4096);
  
    -- Initialize input parameters    
		EXEC spi__input_initialize_numeric @i_trans_id, 0;

		EXEC spi__logging_add
			@i_logging_content = @v_log_info,
			@i_logging_type_identification = 1;
		-------- End Logging --------
 
  -- EXECUTION
  -- =========

     CREATE TABLE #logging_message 
                 (logging_id_parent NVARCHAR(MAX),
                  logging_id NVARCHAR(MAX),
                  trans_id BIGINT,
                  logging_content NVARCHAR(MAX),
                  nestlevel INT,
                  logging_type_identification INT)
                  
    INSERT INTO #logging_message 
                (logging_id_parent,
                 logging_id, 
                 trans_id, 
                 logging_content,         
                 nestlevel,
                 logging_type_identification)                                 
         SELECT (SELECT TOP 1 l1.logging_id 
           FROM #result_set_logging_message l1 
          WHERE l1.trans_id = l.trans_id 
            AND l1.nestlevel < l.nestlevel 
            AND l1.logging_id < l.logging_id 
          ORDER BY l1.nestlevel DESC,
                l1.logging_id DESC)AS logging_id_parent, 
                l.logging_id,l.trans_id,logging_content,nestlevel,logging_type_identification
           FROM #result_set_logging_message l   
          WHERE l.trans_id = @i_trans_id;   
          
    CREATE TABLE #problematic 
                 (trans_id BIGINT,
                  logging_id_parent NVARCHAR(MAX),
                  parent_procedure NVARCHAR(MAX),
                  parent_nestlevel INT,
                  child_procedure NVARCHAR(MAX),
                  child_nestlevel INT,
                  referenced_entity_name NVARCHAR(MAX),
                  missing_nestlevel INT);
           
    WITH problematic AS
    (
    SELECT trans_id,parent_nestlevel,SUBSTRING(a.procedure_1,0, CHARINDEX(' ',a.procedure_1)) AS parent_procedure,child_nestlevel,SUBSTRING(a.procedure_2,0, CHARINDEX(' ',a.procedure_2)) AS child_procedure, missing_nestlevel
    FROM(
    SELECT l1.trans_id,REPLACE(l1.logging_content,'Procedure ','') AS procedure_1, l1.nestlevel AS parent_nestlevel, REPLACE(l2.logging_content,'Procedure ','') AS procedure_2, l2.nestlevel AS child_nestlevel, l2.nestlevel-1 AS missing_nestlevel
    FROM #result_set_logging_message l1
    JOIN #result_set_logging_message l2
    ON  l1.trans_id = l2.trans_id
    AND l1.logging_id + 1 = l2.logging_id
    WHERE l2.nestlevel = l1.nestlevel + 2
    AND l2.logging_content not like '%spi__error_add%') a
    WHERE trans_id = @i_trans_id
    )

    INSERT INTO #problematic
                (trans_id ,
                 parent_procedure ,
                 parent_nestlevel ,
                 child_procedure ,
                 child_nestlevel ,
                 referenced_entity_name ,
                 missing_nestlevel)
    SELECT DISTINCT problematic.trans_id, problematic.parent_procedure, problematic.parent_nestlevel, problematic.child_procedure, problematic.child_nestlevel ,depParent.referenced_entity_name, problematic.missing_nestlevel
    FROM problematic
    JOIN sys.sql_expression_dependencies depParent
    ON OBJECT_NAME(depParent.referencing_id) = problematic.parent_procedure COLLATE Latin1_General_CI_AS 
    AND depParent.is_caller_dependent = 1
    JOIN sys.sql_expression_dependencies depChild
    ON depParent.referenced_entity_name COLLATE Latin1_General_CI_AS  = OBJECT_NAME(depChild.referencing_id) 
    AND depChild.referenced_entity_name COLLATE Latin1_General_CI_AS = problematic.child_procedure 
    WHERE trans_id = @i_trans_id
    
    IF @@ROWCOUNT > 0 BEGIN      

       UPDATE #problematic 
          SET #problematic.logging_id_parent = #logging_message.logging_id
         FROM #logging_message 
         JOIN #problematic
           ON #logging_message.trans_id = #problematic.trans_id
        WHERE #logging_message.logging_content like 'Procedure '+ #problematic.parent_procedure +'%'
             
       INSERT INTO #logging_message                               
                   (logging_id_parent,
                    trans_id, 
                    logging_content,                   
                    nestlevel)                                                   
       SELECT logging_id_parent,trans_id, referenced_entity_name,missing_nestlevel 
         FROM #problematic        

       UPDATE #logging_message 
          SET #logging_message.logging_id = SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 6)
         FROM #problematic 
         JOIN #logging_message
           ON #problematic.trans_id = #logging_message.trans_id
        WHERE #logging_message.logging_content = #problematic.referenced_entity_name

       DECLARE @v_new_log NVARCHAR(MAX); 
       SET @v_new_log = (SELECT logging_id FROM #logging_message JOIN #problematic ON #problematic.trans_id = #logging_message.trans_id WHERE #logging_message.logging_content = #problematic.referenced_entity_name );

       UPDATE #logging_message 
          SET #logging_message.logging_id_parent = @v_new_log
         FROM #problematic 
         JOIN #logging_message
           ON #problematic.trans_id = #logging_message.trans_id
        WHERE #logging_message.nestlevel = #problematic.child_nestlevel

        UPDATE #logging_message
           SET logging_type_identification = 0
         WHERE logging_type_identification IS NULL 

    END

    SELECT * FROM #logging_message ORDER BY logging_id_parent;

    DROP TABLE #logging_message;
    DROP TABLE #problematic;

  -- FINALIZATION
  -- ============

  CONTROLLED_END_OF_PROGRAM:

    IF @v_return_code = @c_return_code_UNEXPECTED_ERROR BEGIN
      SET @v_return_code = @c_return_code_NO_ERRORS;
      GOTO FINAL_END_OF_PROGRAM;
    END;
    
  ERRORS_FOUND:

    SET @v_return_code = @c_return_code_ERROR;

  FINAL_END_OF_PROGRAM:

    RETURN @v_return_code;

END;
