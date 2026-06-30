using Echecs.Enums;

namespace Echecs.Pieces
{
    public partial class Dame : Piece
    {
        #region [Constructeurs - Initialisation]

        public Dame() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Dame(EnumJoueur pJoueur) : base(pJoueur)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Dame" + base.CouleurImage + ".png";
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
