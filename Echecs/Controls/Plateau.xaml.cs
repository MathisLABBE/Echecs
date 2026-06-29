using Echecs.Enums;
using Echecs.Pieces;
using System.Windows.Controls;
using System.Windows.Media;

namespace Echecs.Controls
{
    public partial class Plateau : UserControl
    {
        #region [Champs]

        private const int TAILLE_GRILLE = 8;

        private readonly List<List<Case>> Grille = new(TAILLE_GRILLE);

        #endregion


        #region [Propriétés]

        private readonly Moteur Moteur = Moteur.Instance;

        #endregion


        #region [Constructeurs - Initialisation]

        public Plateau()
        {
            InitializeComponent();

            CreerPlateau();

            Case lCase = Grille[3][3];
            lCase.Piece = new();
        }

        #endregion


        #region [Créer]

        private void CreerPlateau()
        {
            // Supprime la grille
            GrillePlateau.RowDefinitions.Clear();
            GrillePlateau.ColumnDefinitions.Clear();
            GrillePlateau.Children.Clear();
            Grille.Clear();

            // Initialise le grille
            for (int i = 0; i < TAILLE_GRILLE; i++)
            {
                GrillePlateau.RowDefinitions.Add(new RowDefinition());
                GrillePlateau.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Complete la grille avec les cases
            for (int lLigne = 0; lLigne < TAILLE_GRILLE; lLigne++)
            {
                List<Case> lListe = new(TAILLE_GRILLE);

                for (int lColonne = 0; lColonne < TAILLE_GRILLE; ++lColonne)
                {
                    Brush lCouleur = RecupererCouleurCase(lLigne, lColonne);

                    Case lCase = new(lCouleur);

                    lListe.Add(lCase);

                    Grid.SetRow(lCase, lLigne);
                    Grid.SetColumn(lCase, lColonne);
                    GrillePlateau.Children.Add(lCase);
                }

                Grille.Add(lListe);
            }

            // Définit les joueurs
            EnumJoueur lJoueur = Moteur.Joueur;
            EnumJoueur lJoueurAdverse;
            if (lJoueur == EnumJoueur.Joueur1)
            {
                lJoueurAdverse = EnumJoueur.Joueur2;
            }
            else
            {
                lJoueurAdverse = EnumJoueur.Joueur1;
            }

            // Met en place les pions
            for (int lColonne = 0; lColonne < TAILLE_GRILLE; lColonne++)
            {
                Case lCaseAdverse = Grille[1][lColonne];
                lCaseAdverse.Piece = new Pion(lJoueurAdverse);

                Case lCase = Grille[6][lColonne];
                lCase.Piece = new Pion(lJoueur);
            }

            // Met en place les tours
            List<int> lListeColonnesTour = [0, 7];
            foreach (var lColonne in lListeColonnesTour)
            {
                Case lCaseAdverse = Grille[0][lColonne];
                lCaseAdverse.Piece = new Tour(lJoueurAdverse);

                Case lCase = Grille[7][lColonne];
                lCase.Piece = new Tour(lJoueur);
            }

            // Met en place les cavaliers
            List<int> lListeColonnesCavalier = [1, 6];
            foreach (var lCavalier in lListeColonnesCavalier)
            {
                Case lCaseAdverse = Grille[0][lCavalier];
                lCaseAdverse.Piece = new Cavalier(lJoueurAdverse);

                Case lCase = Grille[7][lCavalier];
                lCase.Piece = new Cavalier(lJoueur);
            }

            // Met en place les fous
            List<int> lListeColonnesFou = [2, 5];
            foreach (var lFou in lListeColonnesFou)
            {
                Case lCaseAdverse = Grille[0][lFou];
                lCaseAdverse.Piece = new Fou(lJoueurAdverse);

                Case lCase = Grille[7][lFou];
                lCase.Piece = new Fou(lJoueur);
            }

            // Met en places les dames
            if (Moteur.Joueur == EnumJoueur.Joueur1)
            {
                // Dames
                Case lCaseAdverse = Grille[0][3];
                lCaseAdverse.Piece = new Dame(lJoueurAdverse);

                Case lCase = Grille[7][3];
                lCase.Piece = new Dame(lJoueur);

                // Rois
                lCaseAdverse = Grille[0][4];
                lCaseAdverse.Piece = new Roi(lJoueurAdverse);

                lCase = Grille[7][4];
                lCase.Piece = new Roi(lJoueur);
            }
            else
            {
                // Dames
                Case lCaseAdverse = Grille[0][4];
                lCaseAdverse.Piece = new Dame(lJoueurAdverse);

                Case lCase = Grille[7][4];
                lCase.Piece = new Dame(lJoueur);

                // Rois
                lCaseAdverse = Grille[0][3];
                lCaseAdverse.Piece = new Roi(lJoueurAdverse);

                lCase = Grille[7][3];
                lCase.Piece = new Roi(lJoueur);
            }
        }

        private Brush RecupererCouleurCase(int pLigne, int pColonne)
        {
            Brush lCouleur;

            int lCouleurJoueur;
            if (Moteur.Joueur == EnumJoueur.Joueur1)
            {
                lCouleurJoueur = 0;
            }
            else
            {
                lCouleurJoueur = 1;
            }

            if ((pLigne + pColonne) % 2 == lCouleurJoueur)
            {
                lCouleur = Brushes.White;
            }
            else
            {
                lCouleur = Brushes.DarkGreen;
            }

            return lCouleur;
        }

        #endregion
    }
}
