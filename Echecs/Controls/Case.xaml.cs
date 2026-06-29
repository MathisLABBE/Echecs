using Echecs.Pieces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Echecs.Controls
{
    public partial class Case : UserControl
    {
        #region [Propriétés]

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

        #endregion

        #region [Constructeurs - Initialisation]

        public Case()
        {
            InitializeComponent();
        }

        public Case(Brush pCouleur) : this()
        {
            Couleur = pCouleur;
        }

        #endregion
    }
}