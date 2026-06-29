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

        public Roi(EnumJoueur pJoueur) : base(pJoueur)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Roi" + base.CouleurImage + ".png";
        }

        #endregion
    }
}
