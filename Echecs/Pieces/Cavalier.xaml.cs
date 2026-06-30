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


        #region [Séléctionner]

        private void Piece_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Selectionner(this);
        }

        #endregion
    }
}
