using Echecs.Enums;
using Echecs.Helper;
using Echecs.Pieces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Echecs.Controls
{
    public partial class Plateau : UserControl
    {
        #region [Propriétés]

        public int LignePiecesAdverses = 0;
        public int LignePieces = Moteur.Instance.TailleGrille - 1;
        public int LignePionsAdverses = 1;
        public int LignePions = Moteur.Instance.TailleGrille - 2;

        private readonly Moteur Moteur = Moteur.Instance;

        #endregion


        #region [Constructeurs - Initialisation]

        public Plateau()
        {
            InitializeComponent();

            CreerPlateau();

            Moteur.PromotionDemandee = AfficherChoixPromotion;
        }

        #endregion


        #region [Créer]

        private void CreerPlateau()
        {
            CreerGrille();

            PlacerPions();
            PlacerTours();
            PlacerCavaliers();
            PlacerFous();
            PlacerDamesRois();
        }

        private void CreerGrille()
        {
            // Supprime la grille
            GrillePlateau.RowDefinitions.Clear();
            GrillePlateau.ColumnDefinitions.Clear();
            GrillePlateau.Children.Clear();
            Moteur.Grille.Clear();

            // Initialise le grille
            for (int i = 0; i < Moteur.TailleGrille; i++)
            {
                GrillePlateau.RowDefinitions.Add(new RowDefinition());
                GrillePlateau.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Complete la grille avec les cases
            Case lCase;

            for (int lLigne = 0; lLigne < Moteur.TailleGrille; lLigne++)
            {
                List<Case> lListe = new(Moteur.TailleGrille);

                for (int lColonne = 0; lColonne < Moteur.TailleGrille; ++lColonne)
                {
                    Brush lCouleur = PlateauHelper.RecupererCouleurCase(lLigne, lColonne);

                    lCase = new([lLigne, lColonne], lCouleur);

                    lListe.Add(lCase);

                    Grid.SetRow(lCase, lLigne);
                    Grid.SetColumn(lCase, lColonne);
                    GrillePlateau.Children.Add(lCase);
                }

                Moteur.Grille.Add(lListe);
            }
        }

        private void PlacerPions()
        {
            for (int lColonne = 0; lColonne < Moteur.TailleGrille; lColonne++)
            {
                Case lCaseAdverse = Moteur.Grille[LignePionsAdverses][lColonne];
                lCaseAdverse.Piece = new Pion(Moteur.TeamJoueurAdverse, [LignePionsAdverses, lColonne]);

                Case lCase = Moteur.Grille[LignePions][lColonne];
                lCase.Piece = new Pion(Moteur.TeamJoueur, [LignePions, lColonne]);
            }
        }

        private void PlacerTours()
        {
            List<int> lListeColonnesTour = [0, 7];
            foreach (var lColonne in lListeColonnesTour)
            {
                Case lCaseAdverse = Moteur.Grille[LignePiecesAdverses][lColonne];
                lCaseAdverse.Piece = new Tour(Moteur.TeamJoueurAdverse, [LignePiecesAdverses, lColonne]);

                Case lCase = Moteur.Grille[LignePieces][lColonne];
                lCase.Piece = new Tour(Moteur.TeamJoueur, [LignePieces, lColonne]);
            }
        }

        private void PlacerCavaliers()
        {
            List<int> lListeColonnesCavalier = [1, 6];
            foreach (var lColonne in lListeColonnesCavalier)
            {
                Case lCaseAdverse = Moteur.Grille[LignePiecesAdverses][lColonne];
                lCaseAdverse.Piece = new Cavalier(Moteur.TeamJoueurAdverse, [LignePiecesAdverses, lColonne]);

                Case lCase = Moteur.Grille[LignePieces][lColonne];
                lCase.Piece = new Cavalier(Moteur.TeamJoueur, [LignePieces, lColonne]);
            }
        }

        private void PlacerFous()
        {
            List<int> lListeColonnesFou = [2, 5];
            foreach (var lColonne in lListeColonnesFou)
            {
                Case lCaseAdverse = Moteur.Grille[LignePiecesAdverses][lColonne];
                lCaseAdverse.Piece = new Fou(Moteur.TeamJoueurAdverse, [LignePiecesAdverses, lColonne]);

                Case lCase = Moteur.Grille[LignePieces][lColonne];
                lCase.Piece = new Fou(Moteur.TeamJoueur, [LignePieces, lColonne]);
            }
        }

        private void PlacerDamesRois()
        {
            // Met en places les dames / rois
            int lColonneDame;
            int lColonneRoi;
            if (Moteur.TeamJoueur == EnumJoueur.Blanc)
            {
                lColonneDame = 3;
                lColonneRoi = 4;
            }
            else
            {
                lColonneDame = 4;
                lColonneRoi = 3;
            }

            // Dames
            Case lCaseAdverse = Moteur.Grille[LignePiecesAdverses][lColonneDame];
            lCaseAdverse.Piece = new Dame(Moteur.TeamJoueurAdverse, [LignePiecesAdverses, lColonneDame]);

            Case lCase = Moteur.Grille[LignePieces][lColonneDame];
            lCase.Piece = new Dame(Moteur.TeamJoueur, [LignePieces, lColonneDame]);

            // Rois
            lCaseAdverse = Moteur.Grille[LignePiecesAdverses][lColonneRoi];
            lCaseAdverse.Piece = new Roi(Moteur.TeamJoueurAdverse, [LignePiecesAdverses, lColonneRoi]);

            lCase = Moteur.Grille[LignePieces][lColonneRoi];
            lCase.Piece = new Roi(Moteur.TeamJoueur, [LignePieces, lColonneRoi]);
        }

        #endregion


        #region [Promotion Pion]

        private Case? _CasePromotion;

        private void AfficherChoixPromotion(Case pCase)
        {
            _CasePromotion = pCase;

            StackPanel lPanel = new()
            {
                Orientation = Orientation.Vertical
            };

            AjouterBoutonPromotion(lPanel, EnumPromotion.Dame);
            AjouterBoutonPromotion(lPanel, EnumPromotion.Tour);
            AjouterBoutonPromotion(lPanel, EnumPromotion.Fou);
            AjouterBoutonPromotion(lPanel, EnumPromotion.Cavalier);

            MenuPromotion.Child = lPanel;
            CalquePromotion.Visibility = Visibility.Visible;

            double lTailleCase = ActualWidth / Moteur.TailleGrille;

            Canvas.SetLeft(MenuPromotion, pCase.Colonne * lTailleCase);

            double lTop = pCase.Ligne == 0
                ? 0
                : (Moteur.TailleGrille - 4) * lTailleCase;

            Canvas.SetTop(MenuPromotion, lTop);
        }

        private void AjouterBoutonPromotion(StackPanel pPanel, EnumPromotion pPromotion)
        {
            if (_CasePromotion?.Piece == null)
            {
                return;
            }

            string lCouleur = _CasePromotion.Piece.Couleur;
            string lNomPiece = pPromotion.ToString();
            string lCheminImage = $"{Moteur.CheminImagesPieces}{lCouleur}/{lNomPiece}{lCouleur}.png";

            Button lBouton = new()
            {
                Tag = pPromotion,
                Width = 70,
                Height = 70,
                Padding = new Thickness(4),
                Content = new Image
                {
                    Source = new BitmapImage(new Uri(lCheminImage, UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Uniform
                }
            };

            lBouton.Click += ChoisirPromotion_Click;
            pPanel.Children.Add(lBouton);
        }

        private void ChoisirPromotion_Click(object sender, RoutedEventArgs e)
        {
            if (_CasePromotion?.Piece == null || sender is not Button lBouton)
            {
                return;
            }

            EnumPromotion lPromotion = (EnumPromotion)lBouton.Tag;
            EnumJoueur lTeam = _CasePromotion.Piece.Team;
            List<int> lPosition = _CasePromotion.Position;

            _CasePromotion.Piece = lPromotion switch
            {
                EnumPromotion.Dame => new Dame(lTeam, lPosition),
                EnumPromotion.Tour => new Tour(lTeam, lPosition),
                EnumPromotion.Fou => new Fou(lTeam, lPosition),
                EnumPromotion.Cavalier => new Cavalier(lTeam, lPosition),
                _ => new Dame(lTeam, lPosition)
            };

            CalquePromotion.Visibility = Visibility.Collapsed;
            _CasePromotion = null;

            Moteur.PromotionEnCours = false;
            Moteur.JoueurActuel = Moteur.JoueurAdverse;
        }

        #endregion
    }
}
