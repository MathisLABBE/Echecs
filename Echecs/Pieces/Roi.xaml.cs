using Echecs.Enums;

namespace Echecs.Pieces
{
    public partial class Roi : Piece
    {
        #region [Constructeurs - Initialisation]

        public Roi() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Roi(EnumJoueur pJoueur, List<int> pPosition) : base(pJoueur, pPosition)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Roi" + base.Couleur + ".png";
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
