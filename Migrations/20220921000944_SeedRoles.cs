using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_Empresa.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string RoleEmpresaID = Guid.NewGuid().ToString();
        private string RoleAlunoID = Guid.NewGuid().ToString();
        private string RoleAdminID = Guid.NewGuid().ToString();

        private string UserAdmId = Guid.NewGuid().ToString();       

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRole(migrationBuilder);

        }
        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{RoleAdminID}', 'Adm', 'ADM', null);");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{RoleEmpresaID}', 'Empresa', 'EMPRESA', null);");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{RoleAlunoID}', 'Aluno', 'ALUNO', null);");
        }
        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO 
            [dbo].[AspNetUsers] (
                [Id],[Nome],[Sobrenome],[UserName],[NormalizedUserName],[Email]
               ,[NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp]
               ,[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled]
               ,[LockoutEnd],[LockoutEnabled],[AccessFailedCount])
                VALUES
                ('{UserAdmId}'
               ,'Administradora','Suleima','Admin', N'ADMIN' , N'suleima@empregaSENAI.com' 
               ,N'SULEIMA@EMPREGASENAI.COM' , 0
               ,'AQAAAAEAACcQAAAAEO0EKXLyMsA6YAY7/5j8N4Gi+vr8vP49ELc5VzHHbIOUyWj8r9Vtl4RCdtJAEVWS5g=='
               ,'QFSBEWXRZLALZYQA34SYGYG45I4GA5Z2'
               ,'c7f899f9-4e6b-42ad-9080-a408a884fd7e'
               ,NULL,0,0,NULL,1,0); ");
        }
        private void SeedUserRole(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
                INSERT INTO [dbo].[AspNetUserRoles]
                   ([UserId]
                   ,[RoleId])
                VALUES
                   ('{UserAdmId}'
                   ,'{RoleAlunoID}');
                INSERT INTO [dbo].[AspNetUserRoles]
                   ([UserId]
                   ,[RoleId])
                VALUES
                   ('{UserAdmId}'
                   ,'{RoleAdminID}');
               INSERT INTO [dbo].[AspNetUserRoles]
                   ([UserId]
                   ,[RoleId])
                VALUES
                   ('{UserAdmId}'
                   ,'{RoleEmpresaID}');
            ");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
