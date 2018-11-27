
		INSERT INTO Permission
		        ( PermissionKey ,
		          RoleId ,
		          Title ,
		          Description ,
		          Module ,
		          Status
		        )
		VALUES  ( 'EventViewer_Manage' , 
		          1 , 
		          '查看错误日志' , 
		          NULL , 
		          '设置' ,
		          NULL
		        );

ALTER TABLE CMS_Zone ADD HeadingCode NVARCHAR(100) NULL;
UPDATE CMS_Zone SET HeadingCode = ID;
