using Echecs.Controls;
using Echecs.Enums;
using System.Windows.Media;

namespace Echecs.Pieces
{
    public partial class Pion : Piece
    {
        #region [Propriétés]

        private readonly Moteur Moteur = Moteur.Instance;

        #endregion


        #region [Constructeurs - Initialisation]

        public Pion() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Pion(EnumJoueur pJoueur, List<int> pPosition) : base(pJoueur, pPosition)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Pion" + base.Couleur + ".png";
        }

        #endregion


        #region [Séléctionner]

        private void Piece_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Selectionner(this);
        }

        public override void AfficherCasesDisponibles()
        {
            List<List<Case>> lGrille = Moteur.Grille;

            if (Team == Moteur.TeamJoueur)
            {
                if (lGrille[PositionX - 1][PositionY].Piece == null)
                {
                    lGrille[PositionX - 1][PositionY].CouleurSurlignage = new SolidColorBrush(Color.FromArgb(220, 128, 128, 128));
                }
                if (NbDeplacement == 0)
                {
                    if (lGrille[PositionX - 2][PositionY].Piece == null)
                    {
                        lGrille[PositionX - 2][PositionY].CouleurSurlignage = new SolidColorBrush(Color.FromArgb(220, 128, 128, 128));
                    }
                }
            }
        }

        #endregion
    }
}
