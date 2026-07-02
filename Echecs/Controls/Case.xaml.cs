using Echecs.Pieces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Echecs.Controls
{
    public partial class Case : UserControl
    {
        #region [Propriétés]

        private static Moteur Moteur => Moteur.Instance;

        public Piece? Piece
        {
            get => (Piece?)GetValue(PieceProperty);
            set => SetValue(PieceProperty, value);
        }
        public static readonly DependencyProperty PieceProperty =
            DependencyProperty.Register(nameof(Piece), typeof(Piece), typeof(Case), new PropertyMetadata(null));

        public Brush Couleur
        {
            get => (Brush)GetValue(CouleurProperty);
            set => SetValue(CouleurProperty, value);
        }
        public static readonly DependencyProperty CouleurProperty =
            DependencyProperty.Register(nameof(Couleur), typeof(Brush), typeof(Case), new PropertyMetadata(Brushes.Blue));

        public Brush CouleurSurlignage
        {
            get => (Brush)GetValue(CouleurSurlignageProperty);
            set => SetValue(CouleurSurlignageProperty, value);
        }
        public static readonly DependencyProperty CouleurSurlignageProperty =
            DependencyProperty.Register(nameof(CouleurSurlignage), typeof(Brush), typeof(Case), new PropertyMetadata(Brushes.Transparent));

        // Position
        public List<int> Position;
        public int Ligne => Position[0];
        public int Colonne => Position[1];

        #endregion

        #region [Constructeurs - Initialisation]

        public Case()
        {
            InitializeComponent();

            Position = [];
        }

        public Case(List<int> pPosition, Brush pCouleur) : this()
        {
            Couleur = pCouleur;
            Position = pPosition;
        }

        #endregion


        #region [Séléctionner]

        private void Case_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Moteur.CaseSelectionnee = this;
        }

        #endregion
    }
}