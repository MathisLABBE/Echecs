using Echecs.Enums;
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

            // Met en place les pions
            for (int lColonne = 0; lColonne < TAILLE_GRILLE; lColonne++)
            {
                Case lCase = Grille[1][lColonne];
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
                lCouleur = Brushes.Black;
            }

            return lCouleur;
        }

        #endregion
    }
}
