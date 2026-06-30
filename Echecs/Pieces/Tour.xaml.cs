using Echecs.Enums;

namespace Echecs.Pieces
{
    public partial class Tour : Piece
    {
        #region [Constructeurs - Initialisation]

        public Tour() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Tour(EnumJoueur pJoueur) : base(pJoueur)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Tour" + base.CouleurImage + ".png";
        }

        #endregion


        #region [Séléctionner]

        private void Piece_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Selectionner(this);
        }

        #endregion
    }
}
