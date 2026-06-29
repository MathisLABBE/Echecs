using Echecs.Enums;

namespace Echecs.Pieces
{
    public partial class Fou : Piece
    {
        #region [Constructeurs - Initialisation]

        public Fou() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Fou(EnumJoueur pJoueur) : base(pJoueur)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Fou" + base.CouleurImage + ".png";
        }

        #endregion
    }
}
