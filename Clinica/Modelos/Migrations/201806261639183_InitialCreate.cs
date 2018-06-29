namespace Modelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hora = c.DateTime(nullable: false),
                        Medico_MedicoId = c.Int(),
                        Paciente_PacienteId = c.Int(),
                        Secretaria_SecretariaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Medico_MedicoId)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_PacienteId)
                .ForeignKey("dbo.Secretarias", t => t.Secretaria_SecretariaId)
                .Index(t => t.Medico_MedicoId)
                .Index(t => t.Paciente_PacienteId)
                .Index(t => t.Secretaria_SecretariaId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoId = c.Int(nullable: false, identity: true),
                        CRM = c.String(),
                        Turno = c.String(),
                        Nome = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        Telefone = c.String(),
                        CPF = c.String(),
                        conta_Id = c.Int(),
                        Especialidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.MedicoId)
                .ForeignKey("dbo.Contas", t => t.conta_Id)
                .ForeignKey("dbo.Especialidades", t => t.Especialidade_Id)
                .Index(t => t.conta_Id)
                .Index(t => t.Especialidade_Id);
            
            CreateTable(
                "dbo.Contas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Banco = c.String(),
                        ContaCorrente = c.String(),
                        Agencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        PacienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        Telefone = c.String(),
                        CPF = c.String(),
                        Convenio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PacienteId)
                .ForeignKey("dbo.Convenios", t => t.Convenio_Id)
                .Index(t => t.Convenio_Id);
            
            CreateTable(
                "dbo.Convenios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Empresa = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Secretarias",
                c => new
                    {
                        SecretariaId = c.Int(nullable: false, identity: true),
                        Turno = c.String(),
                        Nome = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        Telefone = c.String(),
                        CPF = c.String(),
                        conta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SecretariaId)
                .ForeignKey("dbo.Contas", t => t.conta_Id)
                .Index(t => t.conta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "Secretaria_SecretariaId", "dbo.Secretarias");
            DropForeignKey("dbo.Secretarias", "conta_Id", "dbo.Contas");
            DropForeignKey("dbo.Consultas", "Paciente_PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Pacientes", "Convenio_Id", "dbo.Convenios");
            DropForeignKey("dbo.Consultas", "Medico_MedicoId", "dbo.Medicos");
            DropForeignKey("dbo.Medicos", "Especialidade_Id", "dbo.Especialidades");
            DropForeignKey("dbo.Medicos", "conta_Id", "dbo.Contas");
            DropIndex("dbo.Secretarias", new[] { "conta_Id" });
            DropIndex("dbo.Pacientes", new[] { "Convenio_Id" });
            DropIndex("dbo.Medicos", new[] { "Especialidade_Id" });
            DropIndex("dbo.Medicos", new[] { "conta_Id" });
            DropIndex("dbo.Consultas", new[] { "Secretaria_SecretariaId" });
            DropIndex("dbo.Consultas", new[] { "Paciente_PacienteId" });
            DropIndex("dbo.Consultas", new[] { "Medico_MedicoId" });
            DropTable("dbo.Secretarias");
            DropTable("dbo.Convenios");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Especialidades");
            DropTable("dbo.Contas");
            DropTable("dbo.Medicos");
            DropTable("dbo.Consultas");
        }
    }
}
