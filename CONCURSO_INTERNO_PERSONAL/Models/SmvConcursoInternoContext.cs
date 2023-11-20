using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class SmvConcursoInternoContext : DbContext
{
    public SmvConcursoInternoContext()
    {
    }

    public SmvConcursoInternoContext(DbContextOptions<SmvConcursoInternoContext> options)
        : base(options)
    {
    }


    public virtual DbSet<ConocimientosLaborale> ConocimientosLaborales { get; set; }


    public virtual DbSet<HabilidadesBlanda> HabilidadesBlandas { get; set; }

    public virtual DbSet<PerfilPuesto> PerfilPuestos { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }


    public virtual DbSet<Preguntum> Pregunta { get; set; }

    public virtual DbSet<Prueba> Pruebas { get; set; }


    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<SolicitudSueldo> SolicitudSueldos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ConocimientosLaborale>(entity =>
        {
            entity.HasKey(e => e.IdCl).HasName("PK__CONOCIMI__8B622F8732904A52");

            entity.ToTable("CONOCIMIENTOS_LABORALES");

            entity.Property(e => e.IdCl).HasColumnName("ID_CL");
            entity.Property(e => e.NomCl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_CL");
        });


        modelBuilder.Entity<HabilidadesBlanda>(entity =>
        {
            entity.HasKey(e => e.IdHb).HasName("PK__HABILIDA__8B62D727800EA020");

            entity.ToTable("HABILIDADES_BLANDAS");

            entity.Property(e => e.IdHb).HasColumnName("ID_HB");
            entity.Property(e => e.NomHb)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_HB");
        });

        modelBuilder.Entity<PerfilPuesto>(entity =>
        {
            entity.HasKey(e => e.IdPp).HasName("PK__PERFIL_P__8B63902B159474F2");

            entity.ToTable("PERFIL_PUESTO");

            entity.Property(e => e.IdPp).HasColumnName("ID_PP");
            entity.Property(e => e.IdCl).HasColumnName("ID_CL");
            entity.Property(e => e.IdHb).HasColumnName("ID_HB");
            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.IdSede).HasColumnName("ID_SEDE");

            entity.HasOne(d => d.oConocimientosLaborales).WithMany(p => p.PerfilPuestos)
                .HasForeignKey(d => d.IdCl)
                .HasConstraintName("FK_IDCL");

            entity.HasOne(d => d.oHabilidadesBlandas).WithMany(p => p.PerfilPuestos)
                .HasForeignKey(d => d.IdHb)
                .HasConstraintName("FK_IDHB");

            entity.HasOne(d => d.oPuesto).WithMany(p => p.PerfilPuestos)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK_IDPUESTO");

            entity.HasOne(d => d.oSede).WithMany(p => p.PerfilPuestos)
                .HasForeignKey(d => d.IdSede)
                .HasConstraintName("FK_IDSEDE");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Idpersonal).HasName("PK__PERSONAL__3C552D96895EBB53");

            entity.ToTable("PERSONAL");

            entity.Property(e => e.Idpersonal).HasColumnName("IDPERSONAL");
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.IdCl).HasColumnName("ID_CL");
            entity.Property(e => e.IdHb).HasColumnName("ID_HB");
            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.NombapePers)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBAPE_PERS");
            entity.Property(e => e.Pcv).HasColumnName("PCV");
            entity.Property(e => e.Pentrevista).HasColumnName("PENTREVISTA");
            entity.Property(e => e.Ppc).HasColumnName("PPC");
            entity.Property(e => e.RefeLaboral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("REFE_LABORAL");

            entity.HasOne(d => d.oConocimientosLaborales).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdCl)
                .HasConstraintName("FK_ID_CL");

            entity.HasOne(d => d.oHabilidadesBlandas).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdHb)
                .HasConstraintName("FK_ID_HB");

            entity.HasOne(d => d.oPuesto).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK_ID_PUESTO");
        });


        modelBuilder.Entity<Preguntum>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__6867FFA4BBC9A05A");

            entity.Property(e => e.IdPregunta).HasColumnName("id_pregunta");
            entity.Property(e => e.Enunciado)
                .HasMaxLength(1500)
                .IsUnicode(false)
                .HasColumnName("enunciado");
            entity.Property(e => e.OpcionA)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("opcion_a");
            entity.Property(e => e.OpcionB)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("opcion_b");
            entity.Property(e => e.OpcionC)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("opcion_c");
            entity.Property(e => e.OpcionD)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("opcion_d");
            entity.Property(e => e.RespuestaCorrecta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("respuesta_correcta");
        });

        modelBuilder.Entity<Prueba>(entity =>
        {
            entity.HasKey(e => e.IdResultado).HasName("PK__Prueba__33A42B304F772385");

            entity.ToTable("Prueba");

            entity.Property(e => e.IdResultado).HasColumnName("id_resultado");
            entity.Property(e => e.IdPregunta).HasColumnName("id_pregunta");
            entity.Property(e => e.Puntaje).HasColumnName("puntaje");
            entity.Property(e => e.RespuestaCorrecta)
                .HasMaxLength(1)
                .HasColumnName("respuesta_correcta");

            entity.HasOne(d => d.oPregunta).WithMany(p => p.Pruebas)
                .HasForeignKey(d => d.IdPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PREGUNTA");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__PUESTO__88D8DDB1167786D9");

            entity.ToTable("PUESTO");

            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.NomPuesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_PUESTO");
            entity.Property(e => e.Sueldo).HasColumnName("SUELDO");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__SEDE__F5FFAE51E4F355FB");

            entity.ToTable("SEDE");

            entity.Property(e => e.IdSede).HasColumnName("ID_SEDE");
            entity.Property(e => e.NomSede)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_SEDE");
        });

        modelBuilder.Entity<SolicitudSueldo>(entity =>
        {
            entity.HasKey(e => e.IdSolicSueldo).HasName("PK__SOLICITU__7D609121808360F6");

            entity.ToTable("SOLICITUD_SUELDO");

            entity.Property(e => e.IdSolicSueldo).HasColumnName("ID_SOLIC_SUELDO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Idpersonal).HasColumnName("IDPERSONAL");
            entity.Property(e => e.SueldoSolic).HasColumnName("SUELDO_SOLIC");

            entity.HasOne(d => d.oPersonal).WithMany(p => p.SolicitudSueldos)
                .HasForeignKey(d => d.Idpersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDPERSONAL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
