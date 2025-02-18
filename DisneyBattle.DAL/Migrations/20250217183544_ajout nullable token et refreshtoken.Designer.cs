﻿// <auto-generated />
using System;
using DisneyBattle.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DisneyBattle.DAL.Migrations
{
    [DbContext(typeof(DisneyBattleContext))]
    [Migration("20250217183544_ajout nullable token et refreshtoken")]
    partial class ajoutnullabletokenetrefreshtoken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Combat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCombat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date_combat")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Equipe1Id")
                        .HasColumnType("int")
                        .HasColumnName("equipe1_id");

                    b.Property<int>("Equipe2Id")
                        .HasColumnType("int")
                        .HasColumnName("equipe2_id");

                    b.Property<int?>("EquipeGagnanteId")
                        .HasColumnType("int")
                        .HasColumnName("equipe_gagnante_id");

                    b.Property<int>("ExperienceGagnee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(100)
                        .HasColumnName("experience_gagnee");

                    b.HasKey("Id")
                        .HasName("PK__combats__3213E83FD3B119FD");

                    b.HasIndex("Equipe1Id");

                    b.HasIndex("Equipe2Id");

                    b.HasIndex("EquipeGagnanteId");

                    b.ToTable("combats", null, t =>
                        {
                            t.HasTrigger("TR_after_combat_update");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.CombatsObjet", b =>
                {
                    b.Property<int>("CombatId")
                        .HasColumnType("int")
                        .HasColumnName("combat_id");

                    b.Property<int>("PersonnageId")
                        .HasColumnType("int")
                        .HasColumnName("personnage_id");

                    b.Property<int>("ObjetId")
                        .HasColumnType("int")
                        .HasColumnName("objet_id");

                    b.Property<int>("Tour")
                        .HasColumnType("int")
                        .HasColumnName("tour");

                    b.HasKey("CombatId", "PersonnageId", "ObjetId", "Tour");

                    b.HasIndex("ObjetId");

                    b.HasIndex("PersonnageId");

                    b.ToTable("combats_objets", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date_creation")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nom");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int")
                        .HasColumnName("utilisateur_id");

                    b.HasKey("Id")
                        .HasName("PK__equipes__3213E83F09C59F4A");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("equipes", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.EquipesPersonnage", b =>
                {
                    b.Property<int>("EquipeId")
                        .HasColumnType("int")
                        .HasColumnName("equipe_id");

                    b.Property<int>("PersonnageId")
                        .HasColumnType("int")
                        .HasColumnName("personnage_id");

                    b.Property<int?>("Position")
                        .HasColumnType("int")
                        .HasColumnName("position");

                    b.HasKey("EquipeId", "PersonnageId");

                    b.HasIndex("PersonnageId");

                    b.ToTable("equipes_personnages", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.HistoriqueNiveaux", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AncienNiveau")
                        .HasColumnType("int")
                        .HasColumnName("ancien_niveau");

                    b.Property<int>("CombatId")
                        .HasColumnType("int")
                        .HasColumnName("combat_id");

                    b.Property<DateTime?>("DateChangement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date_changement")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("NouveauNiveau")
                        .HasColumnType("int")
                        .HasColumnName("nouveau_niveau");

                    b.Property<int>("PersonnageId")
                        .HasColumnType("int")
                        .HasColumnName("personnage_id");

                    b.HasKey("Id")
                        .HasName("PK__historiq__3213E83F0D8A910C");

                    b.HasIndex("CombatId");

                    b.HasIndex("PersonnageId");

                    b.ToTable("historique_niveaux", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Lieux", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nom");

                    b.HasKey("Id")
                        .HasName("PK__lieux__3213E83FE8421A32");

                    b.ToTable("lieux", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Objet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BonusAttaque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("bonus_attaque");

                    b.Property<int?>("BonusDefense")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("bonus_defense");

                    b.Property<int?>("BonusPv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("bonus_pv");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("NiveauRequis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("niveau_requis");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nom");

                    b.HasKey("Id")
                        .HasName("PK__objets__3213E83F399A5385");

                    b.ToTable("objets", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.PalmaresUtilisateur", b =>
                {
                    b.Property<int?>("Defaites")
                        .HasColumnType("int")
                        .HasColumnName("defaites");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal?>("PourcentageVictoire")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("pourcentage_victoire");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pseudo");

                    b.Property<int?>("TotalCombats")
                        .HasColumnType("int")
                        .HasColumnName("total_combats");

                    b.Property<int?>("Victoires")
                        .HasColumnType("int")
                        .HasColumnName("victoires");

                    b.ToTable((string)null);

                    b.ToView("palmares_utilisateurs", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Personnage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlignementId")
                        .HasColumnType("int")
                        .HasColumnName("alignement_id");

                    b.Property<int>("Experience")
                        .HasColumnType("int")
                        .HasColumnName("experience");

                    b.Property<int?>("LieuId")
                        .HasColumnType("int")
                        .HasColumnName("lieu_id");

                    b.Property<int>("Niveau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("niveau");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nom");

                    b.Property<int>("PointsAttaque")
                        .HasColumnType("int")
                        .HasColumnName("points_attaque");

                    b.Property<int>("PointsDefense")
                        .HasColumnType("int")
                        .HasColumnName("points_defense");

                    b.Property<int>("PointsVie")
                        .HasColumnType("int")
                        .HasColumnName("points_vie");

                    b.HasKey("Id")
                        .HasName("PK__personna__3213E83FBE136F56");

                    b.HasIndex("AlignementId");

                    b.HasIndex("LieuId");

                    b.HasIndex(new[] { "Nom" }, "UQ__personna__DF90DC2C89D959C4")
                        .IsUnique();

                    b.ToTable("personnages", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.PointsFaible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nom");

                    b.HasKey("Id")
                        .HasName("PK__points_f__3213E83F6E45F689");

                    b.ToTable("points_faibles", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.TypePersonnage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nom");

                    b.HasKey("Id")
                        .HasName("PK__aligneme__3213E83F961303DF");

                    b.HasIndex(new[] { "Nom" }, "UQ__aligneme__DF90DC2C3FA1DF58")
                        .IsUnique();

                    b.ToTable("typePersonnage", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateInscription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date_inscription")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("mot_de_passe");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pseudo");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__utilisat__3213E83F47B22DBD");

                    b.HasIndex(new[] { "Email" }, "UQ__utilisat__AB6E61649A1F478E")
                        .IsUnique();

                    b.HasIndex(new[] { "Pseudo" }, "UQ__utilisat__EA0EEA2298E82E82")
                        .IsUnique();

                    b.ToTable("utilisateurs", (string)null);
                });

            modelBuilder.Entity("PersonnagesObjetsAutorise", b =>
                {
                    b.Property<int>("PersonnageId")
                        .HasColumnType("int")
                        .HasColumnName("personnage_id");

                    b.Property<int>("ObjetId")
                        .HasColumnType("int")
                        .HasColumnName("objet_id");

                    b.HasKey("PersonnageId", "ObjetId")
                        .HasName("PK_personnages_objets");

                    b.HasIndex("ObjetId");

                    b.ToTable("personnages_objets_autorises", (string)null);
                });

            modelBuilder.Entity("PersonnagesPointsFaible", b =>
                {
                    b.Property<int>("PersonnageId")
                        .HasColumnType("int")
                        .HasColumnName("personnage_id");

                    b.Property<int>("PointFaibleId")
                        .HasColumnType("int")
                        .HasColumnName("point_faible_id");

                    b.HasKey("PersonnageId", "PointFaibleId");

                    b.HasIndex("PointFaibleId");

                    b.ToTable("personnages_points_faibles", (string)null);
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Combat", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.Equipe", "Equipe1")
                        .WithMany("CombatEquipe1s")
                        .HasForeignKey("Equipe1Id")
                        .IsRequired()
                        .HasConstraintName("FK_combats_equipe1");

                    b.HasOne("DisneyBattle.DAL.Entities.Equipe", "Equipe2")
                        .WithMany("CombatEquipe2s")
                        .HasForeignKey("Equipe2Id")
                        .IsRequired()
                        .HasConstraintName("FK_combats_equipe2");

                    b.HasOne("DisneyBattle.DAL.Entities.Equipe", "EquipeGagnante")
                        .WithMany("CombatEquipeGagnantes")
                        .HasForeignKey("EquipeGagnanteId")
                        .HasConstraintName("FK_combats_gagnant");

                    b.Navigation("Equipe1");

                    b.Navigation("Equipe2");

                    b.Navigation("EquipeGagnante");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.CombatsObjet", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.Combat", "Combat")
                        .WithMany("CombatsObjets")
                        .HasForeignKey("CombatId")
                        .IsRequired()
                        .HasConstraintName("FK_combats_objets_combats");

                    b.HasOne("DisneyBattle.DAL.Entities.Objet", "Objet")
                        .WithMany("CombatsObjets")
                        .HasForeignKey("ObjetId")
                        .IsRequired()
                        .HasConstraintName("FK_combats_objets_objets");

                    b.HasOne("DisneyBattle.DAL.Entities.Personnage", "Personnage")
                        .WithMany("CombatsObjets")
                        .HasForeignKey("PersonnageId")
                        .IsRequired()
                        .HasConstraintName("FK_combats_objets_personnages");

                    b.Navigation("Combat");

                    b.Navigation("Objet");

                    b.Navigation("Personnage");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Equipe", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.Utilisateur", "Utilisateur")
                        .WithMany("Equipes")
                        .HasForeignKey("UtilisateurId")
                        .IsRequired()
                        .HasConstraintName("FK_equipes_utilisateurs");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.EquipesPersonnage", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.Equipe", "Equipe")
                        .WithMany("EquipesPersonnages")
                        .HasForeignKey("EquipeId")
                        .IsRequired()
                        .HasConstraintName("FK_equipes_personnages_equipes");

                    b.HasOne("DisneyBattle.DAL.Entities.Personnage", "Personnage")
                        .WithMany("EquipesPersonnages")
                        .HasForeignKey("PersonnageId")
                        .IsRequired()
                        .HasConstraintName("FK_equipes_personnages_personnages");

                    b.Navigation("Equipe");

                    b.Navigation("Personnage");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.HistoriqueNiveaux", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.Combat", "Combat")
                        .WithMany("HistoriqueNiveauxes")
                        .HasForeignKey("CombatId")
                        .IsRequired()
                        .HasConstraintName("FK_historique_combats");

                    b.HasOne("DisneyBattle.DAL.Entities.Personnage", "Personnage")
                        .WithMany("HistoriqueNiveauxes")
                        .HasForeignKey("PersonnageId")
                        .IsRequired()
                        .HasConstraintName("FK_historique_personnages");

                    b.Navigation("Combat");

                    b.Navigation("Personnage");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Personnage", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.TypePersonnage", "TypePersonnage")
                        .WithMany("Personnages")
                        .HasForeignKey("AlignementId")
                        .IsRequired()
                        .HasConstraintName("FK_personnages_alignements");

                    b.HasOne("DisneyBattle.DAL.Entities.Lieux", "Lieu")
                        .WithMany("Personnages")
                        .HasForeignKey("LieuId")
                        .HasConstraintName("FK_personnages_lieux");

                    b.Navigation("Lieu");

                    b.Navigation("TypePersonnage");
                });

            modelBuilder.Entity("PersonnagesObjetsAutorise", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.Objet", null)
                        .WithMany()
                        .HasForeignKey("ObjetId")
                        .IsRequired()
                        .HasConstraintName("FK_objets_autorises_objets");

                    b.HasOne("DisneyBattle.DAL.Entities.Personnage", null)
                        .WithMany()
                        .HasForeignKey("PersonnageId")
                        .IsRequired()
                        .HasConstraintName("FK_objets_autorises_personnages");
                });

            modelBuilder.Entity("PersonnagesPointsFaible", b =>
                {
                    b.HasOne("DisneyBattle.DAL.Entities.Personnage", null)
                        .WithMany()
                        .HasForeignKey("PersonnageId")
                        .IsRequired()
                        .HasConstraintName("FK_points_faibles_personnages");

                    b.HasOne("DisneyBattle.DAL.Entities.PointsFaible", null)
                        .WithMany()
                        .HasForeignKey("PointFaibleId")
                        .IsRequired()
                        .HasConstraintName("FK_points_faibles_points");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Combat", b =>
                {
                    b.Navigation("CombatsObjets");

                    b.Navigation("HistoriqueNiveauxes");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Equipe", b =>
                {
                    b.Navigation("CombatEquipe1s");

                    b.Navigation("CombatEquipe2s");

                    b.Navigation("CombatEquipeGagnantes");

                    b.Navigation("EquipesPersonnages");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Lieux", b =>
                {
                    b.Navigation("Personnages");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Objet", b =>
                {
                    b.Navigation("CombatsObjets");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Personnage", b =>
                {
                    b.Navigation("CombatsObjets");

                    b.Navigation("EquipesPersonnages");

                    b.Navigation("HistoriqueNiveauxes");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.TypePersonnage", b =>
                {
                    b.Navigation("Personnages");
                });

            modelBuilder.Entity("DisneyBattle.DAL.Entities.Utilisateur", b =>
                {
                    b.Navigation("Equipes");
                });
#pragma warning restore 612, 618
        }
    }
}
