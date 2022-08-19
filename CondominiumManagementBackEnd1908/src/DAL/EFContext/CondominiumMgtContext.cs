using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAL.EFEntities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFContext
{
    public partial class CondominiumMgtContext : DbContext
    {
        public CondominiumMgtContext()
        {
        }

        public CondominiumMgtContext(DbContextOptions<CondominiumMgtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Annexes> Annexes { get; set; }
        public virtual DbSet<Civilites> Civilites { get; set; }
        public virtual DbSet<CodesPcmn> CodesPcmn { get; set; }
        public virtual DbSet<ComptesBque> ComptesBque { get; set; }
        public virtual DbSet<Coproprietaires> Coproprietaires { get; set; }
        public virtual DbSet<Coproprietes> Coproprietes { get; set; }
        public virtual DbSet<Decomptes> Decomptes { get; set; }
        public virtual DbSet<Destinations> Destinations { get; set; }
        public virtual DbSet<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }
        public virtual DbSet<Fournisseurs> Fournisseurs { get; set; }
        public virtual DbSet<Groupements> Groupements { get; set; }
        public virtual DbSet<Groupes> Groupes { get; set; }
        public virtual DbSet<LignesDecomptes> LignesDecomptes { get; set; }
        public virtual DbSet<LignesDocumentsFournisseurs> LignesDocumentsFournisseurs { get; set; }
        public virtual DbSet<Localisations> Localisations { get; set; }
        public virtual DbSet<Lots> Lots { get; set; }
        public virtual DbSet<MatchingsPaiements> MatchingsPaiements { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Paiements> Paiements { get; set; }
        public virtual DbSet<Periodes> Periodes { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Quotites> Quotites { get; set; }
        public virtual DbSet<RaisonsCloture> RaisonsCloture { get; set; }
        public virtual DbSet<Sexes> Sexes { get; set; }
        public virtual DbSet<TypesDocumentFournisseur> TypesDocumentFournisseur { get; set; }
        public virtual DbSet<TypesLot> TypesLot { get; set; }
        public virtual DbSet<TypesMessage> TypesMessage { get; set; }
        public virtual DbSet<TypesTva> TypesTva { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("ConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annexes>(entity =>
            {
                entity.HasKey(e => e.IdAnnexe);

                entity.Property(e => e.Remarque).HasMaxLength(50);

                entity.HasOne(d => d.IdMessageNavigation)
                    .WithMany(p => p.Annexes)
                    .HasForeignKey(d => d.IdMessage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Annexes-Messages");
            });

            modelBuilder.Entity<Civilites>(entity =>
            {
                entity.HasKey(e => e.IdCivilite);

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CodesPcmn>(entity =>
            {
                entity.HasKey(e => e.IdCodePcmn);

                entity.ToTable("CodesPCMN");

                entity.Property(e => e.IdCodePcmn).HasColumnName("IdCodePCMN");

                entity.Property(e => e.CodePcmn).HasColumnName("CodePCMN");

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ComptesBque>(entity =>
            {
                entity.HasKey(e => e.IdCompteBque);

                entity.Property(e => e.ActifON).HasColumnName("ActifO/N");

                entity.Property(e => e.IdCoproprietaire)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NomBque)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumCompteBque)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCoproprietaireNavigation)
                    .WithMany(p => p.ComptesBque)
                    .HasForeignKey(d => d.IdCoproprietaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComptesBque-Coproprietaires");
            });

            modelBuilder.Entity<Coproprietaires>(entity =>
            {
                entity.HasKey(e => e.IdCoproprietaire);

                entity.Property(e => e.IdCoproprietaire).HasMaxLength(50);

                entity.Property(e => e.Adresse).IsRequired();

                entity.Property(e => e.DateCloture).HasColumnType("date");

                entity.Property(e => e.DateCreation).HasColumnType("date");

                entity.Property(e => e.DateNaissance).HasColumnType("date");

                entity.Property(e => e.Nom).IsRequired();

                entity.Property(e => e.NumNiss)
                    .HasColumnName("NumNISS")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCiviliteNavigation)
                    .WithMany(p => p.Coproprietaires)
                    .HasForeignKey(d => d.IdCivilite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCivilite");

                entity.HasOne(d => d.IdRaisonClotureNavigation)
                    .WithMany(p => p.Coproprietaires)
                    .HasForeignKey(d => d.IdRaisonCloture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdRaisonCloture");
            });

            modelBuilder.Entity<Coproprietes>(entity =>
            {
                entity.HasKey(e => e.IdCopropriete);

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.Property(e => e.IdCoproprietaire)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumContrat).HasMaxLength(50);

                entity.HasOne(d => d.IdCoproprietaireNavigation)
                    .WithMany(p => p.Coproprietes)
                    .HasForeignKey(d => d.IdCoproprietaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCoproprietaire");

                entity.HasOne(d => d.IdLotNavigation)
                    .WithMany(p => p.Coproprietes)
                    .HasForeignKey(d => d.IdLot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdLot");
            });

            modelBuilder.Entity<Decomptes>(entity =>
            {
                entity.HasKey(e => e.IdDecompte);

                entity.Property(e => e.DateCreation).HasColumnType("date");

                entity.Property(e => e.DateDebutDecompte).HasColumnType("date");

                entity.Property(e => e.DateEcheance).HasColumnType("date");

                entity.Property(e => e.DateFinDecompte).HasColumnType("date");

                entity.Property(e => e.IdCoproprietaire)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdTypeTva).HasColumnName("IdTypeTVA");

                entity.Property(e => e.MontantTotalTva).HasColumnName("MontantTotalTVA");

                entity.Property(e => e.SoldeON).HasColumnName("SoldeO/N");

                entity.HasOne(d => d.IdCoproprietaireNavigation)
                    .WithMany(p => p.Decomptes)
                    .HasForeignKey(d => d.IdCoproprietaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coproprietaires-Decomptes");

                entity.HasOne(d => d.IdGroupementNavigation)
                    .WithMany(p => p.Decomptes)
                    .HasForeignKey(d => d.IdGroupement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdGroupement");

                entity.HasOne(d => d.IdPeriodeNavigation)
                    .WithMany(p => p.Decomptes)
                    .HasForeignKey(d => d.IdPeriode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Decomptes-Periodes");

                entity.HasOne(d => d.IdTypeTvaNavigation)
                    .WithMany(p => p.Decomptes)
                    .HasForeignKey(d => d.IdTypeTva)
                    .HasConstraintName("FK_IdTypeTVA");
            });

            modelBuilder.Entity<Destinations>(entity =>
            {
                entity.HasKey(e => e.IdDestination);

                entity.Property(e => e.IdDestinataire)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdDestinataireNavigation)
                    .WithMany(p => p.Destinations)
                    .HasForeignKey(d => d.IdDestinataire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdDestinataire");

                entity.HasOne(d => d.IdMessageNavigation)
                    .WithMany(p => p.Destinations)
                    .HasForeignKey(d => d.IdMessage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdMessage");
            });

            modelBuilder.Entity<DocumentsFournisseurs>(entity =>
            {
                entity.HasKey(e => e.IdDocumentFournisseur);

                entity.Property(e => e.DateDocument).HasColumnType("date");

                entity.Property(e => e.DateEcheance).HasColumnType("date");

                entity.Property(e => e.DateEnregistrement).HasColumnType("date");

                entity.Property(e => e.IdTypeTva).HasColumnName("IdTypeTVA");

                entity.Property(e => e.MontantTotalTvacdocument).HasColumnName("MontantTotalTVACDocument");

                entity.Property(e => e.MontantTva).HasColumnName("MontantTVA");

                entity.HasOne(d => d.IdFournisseurNavigation)
                    .WithMany(p => p.DocumentsFournisseurs)
                    .HasForeignKey(d => d.IdFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdFournisseur");

                entity.HasOne(d => d.IdPeriodeNavigation)
                    .WithMany(p => p.DocumentsFournisseurs)
                    .HasForeignKey(d => d.IdPeriode)
                    .HasConstraintName("FK_DocumentsFournisseurs-Periodes");

                entity.HasOne(d => d.IdTypeDocumentFournisseurNavigation)
                    .WithMany(p => p.DocumentsFournisseurs)
                    .HasForeignKey(d => d.IdTypeDocumentFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdTypeDocumentFournisseur");

                entity.HasOne(d => d.IdTypeTvaNavigation)
                    .WithMany(p => p.DocumentsFournisseurs)
                    .HasForeignKey(d => d.IdTypeTva)
                    .HasConstraintName("FK_DocumentsFournisseurs-TypesTVA");
            });

            modelBuilder.Entity<Fournisseurs>(entity =>
            {
                entity.HasKey(e => e.IdFournisseur);

                entity.Property(e => e.Activite)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NomContact)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumAgregation).HasMaxLength(50);

                entity.Property(e => e.NumRegistre).HasMaxLength(50);

                entity.Property(e => e.NumTel).HasMaxLength(50);

                entity.Property(e => e.NumTva)
                    .HasColumnName("NumTVA")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Groupements>(entity =>
            {
                entity.HasKey(e => e.IdGroupement);

                entity.Property(e => e.DateDebutGroupement).HasColumnType("date");

                entity.Property(e => e.DateFinGroupement).HasColumnType("date");

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany(p => p.Groupements)
                    .HasForeignKey(d => d.IdGroupe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdGroupe");

                entity.HasOne(d => d.IdLotNavigation)
                    .WithMany(p => p.Groupements)
                    .HasForeignKey(d => d.IdLot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groupements-Lots");
            });

            modelBuilder.Entity<Groupes>(entity =>
            {
                entity.HasKey(e => e.IdGroupe);

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LignesDecomptes>(entity =>
            {
                entity.HasKey(e => e.IdLigneDecompte);

                entity.Property(e => e.DateDebutLigne).HasColumnType("date");

                entity.Property(e => e.DateFinLigne).HasColumnType("date");

                entity.Property(e => e.IdCodePcmn).HasColumnName("IdCodePCMN");

                entity.Property(e => e.MontantTotalTvacligne).HasColumnName("MontantTotalTVACLigne");

                entity.Property(e => e.MontantTvaligne).HasColumnName("MontantTVALigne");

                entity.HasOne(d => d.IdCodePcmnNavigation)
                    .WithMany(p => p.LignesDecomptes)
                    .HasForeignKey(d => d.IdCodePcmn)
                    .HasConstraintName("FK_LignesDecomptes-CodesPCMN");

                entity.HasOne(d => d.IdDecompteNavigation)
                    .WithMany(p => p.LignesDecomptes)
                    .HasForeignKey(d => d.IdDecompte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LignesDecomptes-Decomptes");

                entity.HasOne(d => d.IdLigneDocumentFournisseurNavigation)
                    .WithMany(p => p.LignesDecomptes)
                    .HasForeignKey(d => d.IdLigneDocumentFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdLigneDocumentFournisseur");

                entity.HasOne(d => d.IdQuotiteNavigation)
                    .WithMany(p => p.LignesDecomptes)
                    .HasForeignKey(d => d.IdQuotite)
                    .HasConstraintName("FK_IdQuotite");
            });

            modelBuilder.Entity<LignesDocumentsFournisseurs>(entity =>
            {
                entity.HasKey(e => e.IdLigneDocumentFournisseur);

                entity.Property(e => e.DateDebutLigne).HasColumnType("date");

                entity.Property(e => e.DateFinLigne).HasColumnType("date");

                entity.Property(e => e.IdCodePcmn).HasColumnName("IdCodePCMN");

                entity.Property(e => e.IdTypeTva).HasColumnName("IdTypeTVA");

                entity.Property(e => e.MontantTotalTvacligne).HasColumnName("MontantTotalTVACLigne");

                entity.Property(e => e.MontantTvaligne).HasColumnName("MontantTVALigne");

                entity.HasOne(d => d.IdCodePcmnNavigation)
                    .WithMany(p => p.LignesDocumentsFournisseurs)
                    .HasForeignKey(d => d.IdCodePcmn)
                    .HasConstraintName("FK_LignesDocumentsFournisseurs-CodesPCMN");

                entity.HasOne(d => d.IdDocumentFournisseurNavigation)
                    .WithMany(p => p.LignesDocumentsFournisseurs)
                    .HasForeignKey(d => d.IdDocumentFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdDocumentFournisseur");

                entity.HasOne(d => d.IdTypeTvaNavigation)
                    .WithMany(p => p.LignesDocumentsFournisseurs)
                    .HasForeignKey(d => d.IdTypeTva)
                    .HasConstraintName("FK_LignesDocumentsFournisseurs-TypesTVA");
            });

            modelBuilder.Entity<Localisations>(entity =>
            {
                entity.HasKey(e => e.IdLocalisation);

                entity.Property(e => e.Adresse).IsRequired();

                entity.Property(e => e.CodeLocalisation).HasMaxLength(50);

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");
            });

            modelBuilder.Entity<Lots>(entity =>
            {
                entity.HasKey(e => e.IdLot);

                entity.Property(e => e.CodeLot)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.HasOne(d => d.IdLocalisationNavigation)
                    .WithMany(p => p.Lots)
                    .HasForeignKey(d => d.IdLocalisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdLocalisation");

                entity.HasOne(d => d.IdTypeLotNavigation)
                    .WithMany(p => p.Lots)
                    .HasForeignKey(d => d.IdTypeLot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdTypeLot");
            });

            modelBuilder.Entity<MatchingsPaiements>(entity =>
            {
                entity.HasKey(e => e.IdMatchingPaiement);

                entity.Property(e => e.DateEnregistrement).HasColumnType("date");

                entity.HasOne(d => d.IdDecompteNavigation)
                    .WithMany(p => p.MatchingsPaiements)
                    .HasForeignKey(d => d.IdDecompte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchingPaiements-Decomptes");

                entity.HasOne(d => d.IdPaiementNavigation)
                    .WithMany(p => p.MatchingsPaiements)
                    .HasForeignKey(d => d.IdPaiement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdPaiement");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.IdMessage);

                entity.Property(e => e.ContenuMessage).HasMaxLength(250);

                entity.Property(e => e.DateExpedition).HasColumnType("date");

                entity.Property(e => e.IdExpediteur)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TitreMessage)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdExpediteurNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdExpediteur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdExpediteur");

                entity.HasOne(d => d.IdTypeMessageNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdTypeMessage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdTypeMessage");
            });

            modelBuilder.Entity<Paiements>(entity =>
            {
                entity.HasKey(e => e.IdPaiement);

                entity.Property(e => e.DateDocument).HasColumnType("date");

                entity.Property(e => e.DateEnregistrement).HasColumnType("date");

                entity.Property(e => e.NomPayeurAutre).HasMaxLength(50);

                entity.Property(e => e.NumDocument)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCompteBquePayeurNavigation)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdCompteBquePayeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCompteBquePayeur");
            });

            modelBuilder.Entity<Periodes>(entity =>
            {
                entity.HasKey(e => e.IdPeriode);

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.HasKey(e => e.IdPhoto);

                entity.Property(e => e.Ressource).IsRequired();

                entity.HasOne(d => d.IdAnnexeNavigation)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.IdAnnexe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdAnnexe");
            });

            modelBuilder.Entity<Quotites>(entity =>
            {
                entity.HasKey(e => e.IdQuotite);

                entity.Property(e => e.ActifON).HasColumnName("ActifO/N");

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.HasOne(d => d.IdLocalisationNavigation)
                    .WithMany(p => p.Quotites)
                    .HasForeignKey(d => d.IdLocalisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quotites-Localisations");

                entity.HasOne(d => d.IdLotNavigation)
                    .WithMany(p => p.Quotites)
                    .HasForeignKey(d => d.IdLot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quotites-Lots");
            });

            modelBuilder.Entity<RaisonsCloture>(entity =>
            {
                entity.HasKey(e => e.IdRaisonCloture);

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sexes>(entity =>
            {
                entity.HasKey(e => e.IdSexe);

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypesDocumentFournisseur>(entity =>
            {
                entity.HasKey(e => e.IdTypeDocumentFournisseur);

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<TypesLot>(entity =>
            {
                entity.HasKey(e => e.IdTypeLot);

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<TypesMessage>(entity =>
            {
                entity.HasKey(e => e.IdTypeMessage);

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<TypesTva>(entity =>
            {
                entity.HasKey(e => e.IdTypeTva);

                entity.ToTable("TypesTVA");

                entity.Property(e => e.IdTypeTva).HasColumnName("IdTypeTVA");

                entity.Property(e => e.ActifON).HasColumnName("ActifO/N");

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



        

    }
}
