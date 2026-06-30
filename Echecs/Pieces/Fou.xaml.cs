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


        #region [Séléctionner]

        private void Piece_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Selectionner(this);
        }

        #endregion
    }
}
