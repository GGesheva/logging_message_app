CREATE PROCEDURE [dbo].[spe__search_logging_message] 
( @i_trans_id BIGINT = NULL,
  @i_logging_channel_code NVARCHAR(128) = NULL,
  @i_logging_type_identification INT = NULL,
  @i_machine_name NVARCHAR(50) = NULL,
  @i_logging_content NVARCHAR(MAX) = NULL,
  @i_spid INT = NULL,
  @i_date_from DATETIME = NULL, 
  @i_date_to DATETIME = NULL) 
AS
BEGIN

  -- DECLARATION
  -- ===========

  -- Errors

  -- Constants
  DECLARE @c_return_code_NO_ERRORS                          INT;             SET @c_return_code_NO_ERRORS = 0;
  DECLARE @c_return_code_ERROR                              INT;             SET @c_return_code_ERROR = 1;
  DECLARE @c_return_code_UNEXPECTED_ERROR                   INT;             SET @c_return_code_UNEXPECTED_ERROR = 9;
  DECLARE @c_message_type_ERROR                             NVARCHAR(1);     SET @c_message_type_ERROR = 'E';

  -- Variables
  DECLARE @v_return_code                                    INT;             SET @v_return_code = @c_return_code_UNEXPECTED_ERROR;
  DECLARE @v_trans_id                                       BIGINT;          SET @v_trans_id = 0;
  DECLARE @v_local_return_code                              INT;             SET @v_local_return_code = @c_return_code_UNEXPECTED_ERROR;
  DECLARE @v_local_transaction_active                       BIT;             SET @v_local_transaction_active = 0;
  DECLARE @v_log_info                                       NVARCHAR(2048);  SET @v_log_info = ''; 

  DECLARE @v_sql_error_number                               INT;
  DECLARE @v_sql_error_severity                             INT;
  DECLARE @v_sql_error_state                                INT;
  DECLARE @v_sql_error_procedure                            NVARCHAR(126);
  DECLARE @v_sql_error_line                                 INT;
  DECLARE @v_sql_error_message                              NVARCHAR(2048);
  DECLARE @v_error_field                                    NVARCHAR(256);    SET @v_error_field = NULL;
  DECLARE @v_log_rollback_message                           NVARCHAR(2048);   SET @v_log_rollback_message = ''; 
  DECLARE @v_log_saved_loggings                             VARBINARY(MAX); 

  DECLARE @v_trans_id_param                                 BIGINT;   
  DECLARE @v_sql                                            NVARCHAR(4000);         


  -- INITIALIZATION
  -- ==============
  BEGIN TRY

    -- Initialize session
    SET NOCOUNT ON;
    
    SET @v_local_transaction_active = 0;
    
    EXEC spi__session_initialize
      @i_initiator = 'spe__search_logging_message', 
      @o_trans_id = @v_trans_id OUTPUT; 

    EXEC spi__error_initialize;

     -- Log execution 
    SET @v_log_info = REPLACE(REPLACE(
      'Procedure bmever.spe__search_logging_message' +
      ' <@i_trans_id = '                         +         RTRIM(COALESCE(CAST(@i_trans_id AS NVARCHAR(MAX)), 'NULL')) +
      ', @i_logging_channel_code = '             + 'N''' + RTRIM(COALESCE(@i_logging_channel_code, '<null>')) + '''' +
      ', @i_logging_type_identification = '      +         RTRIM(COALESCE(CAST(@i_logging_type_identification AS NVARCHAR(MAX)), 'NULL')) +
      ', @i_machine_name = '                     + 'N''' + RTRIM(COALESCE(@i_machine_name, '<null>')) + '''' +
      ', @i_logging_content = '                  + 'N''' + RTRIM(COALESCE(@i_logging_content, '<null>')) + '''' +
      ', @i_spid = '                             +         RTRIM(COALESCE(CAST(@i_spid AS NVARCHAR(MAX)), 'NULL')) +
      ', @i_date_from = '                        +         RTRIM(COALESCE(CAST(@i_date_from AS NVARCHAR(MAX)), 'NULL')) +
      ', @i_date_to = '                          +         RTRIM(COALESCE(CAST(@i_date_to AS NVARCHAR(MAX)), 'NULL')) +
      '>', 'N''<null>''', 'NULL'), '''<null>''', 'NULL');
 
    EXEC spi__logging_add
      @i_logging_content = @v_log_info,
      @i_logging_type_identification = 1,
      @i_proc_id = @@PROCID;
 
    -- Initialize input parameters
    EXEC spi__input_initialize_numeric   @i_trans_id, 0;
    EXEC spi__input_initialize_char      @i_logging_channel_code;
    EXEC spi__input_initialize_numeric   @i_logging_type_identification, 0;
    EXEC spi__input_initialize_char      @i_machine_name;
    EXEC spi__input_initialize_char      @i_logging_content;
    EXEC spi__input_initialize_numeric   @i_spid, 0;
    EXEC spi__input_initialize_char      @i_date_from;
    EXEC spi__input_initialize_char      @i_date_to;

    -- Initialize output parameters


  -- EXECUTION
  -- =========

    -- Start transaction
    -- ----------------- 
    BEGIN TRANSACTION;
    SET @v_local_transaction_active = 1;

    

    -- Validate & execute (if appropiate)
    -- ----------------------------------

   IF (@i_trans_id IS NULL
   AND @i_logging_channel_code IS NULL
   AND @i_logging_type_identification IS NULL
   AND @i_machine_name IS NULL
   AND @i_logging_content IS NULL
   AND @i_spid IS NULL
   AND @i_date_from IS NULL 
   AND @i_date_to IS NULL)


   BEGIN
    SET @v_sql = 'SELECT TOP 1000 * FROM logging_message' 
   END
   ELSE BEGIN

    SET @v_sql =  'SELECT * FROM logging_message WHERE 1=1';
    
    IF @i_trans_id IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND trans_id = '+ CAST(@i_trans_id AS NVARCHAR(MAX)) 
    END

    IF @i_logging_channel_code IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND logging_channel_code = ' + '''' + @i_logging_channel_code + '''';
    END
    
    IF @i_logging_type_identification IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND logging_type_identification = ' + CAST(@i_logging_type_identification AS NVARCHAR(MAX))
    END
   
    IF @i_machine_name IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND machine_name LIKE ' + '''%' + @i_machine_name + '%'''
    END
         
    IF @i_logging_content IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND logging_content LIKE ' + '''%' + @i_logging_content + '%'''
    END
   
    IF @i_spid IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND spid = ' + CAST(@i_spid AS NVARCHAR(MAX))
    END

    IF @i_date_from IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND creation_dt >= ' + '''' + CONVERT(varchar, @i_date_from, 113) + ''''
    END

    IF @i_date_to IS NOT NULL BEGIN
      SET @v_sql = @v_sql + ' AND creation_dt <= ' + '''' + CONVERT(varchar, @i_date_to, 113) + ''''
    END 

   END

     PRINT @v_sql
   EXEC sp_executesql @v_sql 
   
   CREATE TABLE #result_set_logging_message
                (logging_id NVARCHAR(MAX),
                 trans_id BIGINT,
                 logging_channel_code NVARCHAR(128),
                 logging_program NVARCHAR(50),
                 logging_type_identification INT,
                 logging_content NVARCHAR(MAX),
                 message_code NVARCHAR(10),
                 parameters_values NVARCHAR(256),
                 operating_system_user NVARCHAR(50),
                 machine_name NVARCHAR(50),
                 initiator NVARCHAR(128),
                 nestlevel INT,
                 spid int,
                 object_name NVARCHAR(256),
                 cschema_owner NVARCHAR(30),
                 creation_dt datetime,
                 his_flag NVARCHAR(5))

      

   INSERT #result_set_logging_message 
   EXECUTE sp_executesql @v_sql 
        
   ---- Cursors  
   DECLARE cur_trans_id CURSOR LOCAL FAST_FORWARD READ_ONLY FOR 
   SELECT DISTINCT trans_id FROM #result_set_logging_message; 

   ---- Open cursor 
   OPEN cur_trans_id;

   ---- Fetch from cursor
   FETCH FROM cur_trans_id INTO 
   @v_trans_id_param

   ---- Loop through records 
   WHILE @@fetch_status <> -1 BEGIN
     -- call [dbo].[spe__temp_table_test] for each trans_id
     EXEC @v_local_return_code = spi__treeview_nodes
      @i_trans_id = @v_trans_id_param       
  
     IF @v_local_return_code = @c_return_code_ERROR BEGIN
       GOTO ERRORS_FOUND;
     END ELSE IF @v_local_return_code = @c_return_code_UNEXPECTED_ERROR BEGIN
       SET @v_return_code = @c_return_code_UNEXPECTED_ERROR;
     GOTO FINAL_END_OF_PROGRAM;
     END; 

     -- Fetch next from cursor
     FETCH FROM cur_trans_id INTO 
     @v_trans_id_param

   END;

   ---- Close & deallocate cursor 

   CLOSE cur_trans_id;
   DEALLOCATE cur_trans_id;    

   DROP TABLE #result_set_logging_message;



  -- FINALIZATION
  -- ============

CONTROLLED_END_OF_PROGRAM:

    IF @v_return_code = @c_return_code_UNEXPECTED_ERROR BEGIN
      SET @v_return_code = @c_return_code_NO_ERRORS;    -- No unexpected error occurred
      GOTO FINAL_END_OF_PROGRAM;
    END;


ERRORS_FOUND:

    SET @v_return_code = @c_return_code_ERROR;


FINAL_END_OF_PROGRAM:
  END TRY 

  BEGIN CATCH
  
    SET @v_return_code = @c_return_code_UNEXPECTED_ERROR;
    SELECT @v_sql_error_number = ERROR_NUMBER(), @v_sql_error_severity = ERROR_SEVERITY(), @v_sql_error_state = ERROR_STATE(), @v_sql_error_procedure = ERROR_PROCEDURE(), @v_sql_error_line = ERROR_LINE(), @v_sql_error_message = ERROR_MESSAGE();
    EXEC spi__error_add_exception  @v_sql_error_number, @v_sql_error_severity, @v_sql_error_state, @v_sql_error_procedure, @v_sql_error_line, @v_sql_error_message, 
                                   @v_error_field, @v_log_rollback_message OUTPUT;
  END CATCH

  EXEC spi__error_list;

  IF @v_local_transaction_active = 1 BEGIN
    IF @v_return_code = @c_return_code_NO_ERRORS BEGIN
      COMMIT TRANSACTION;
    END ELSE IF XACT_STATE() <> 0 BEGIN
      EXEC spi__logging_save    @v_trans_id, @v_log_saved_loggings OUTPUT;
      ROLLBACK  TRANSACTION;
      EXEC spi__logging_restore @v_log_saved_loggings;
      EXEC spi__logging_add_transaction_rollback_info  @v_log_rollback_message;
    END;
  END;

  RETURN @v_return_code;

END;
