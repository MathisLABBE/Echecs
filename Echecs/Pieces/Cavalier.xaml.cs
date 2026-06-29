using Echecs.Enums;

namespace Echecs.Pieces
{
    public partial class Cavalier : Piece
    {
        #region [Constructeurs - Initialisation]

        public Cavalier() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Cavalier(EnumJoueur pJoueur) : base(pJoueur)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Cavalier" + base.CouleurImage + ".png";
        }

        #endregion
    }
}
