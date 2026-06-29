using Echecs.Enums;

namespace Echecs.Pieces
{
    public partial class Pion : Piece
    {
        #region [Constructeurs - Initialisation]

        public Pion() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Pion(EnumJoueur pJoueur) : base(pJoueur)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Pion" + base.CouleurImage + ".png";
        }

        #endregion
    }
}
