using Echecs.Controls;
using Echecs.Enums;
using Echecs.Helper;

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

        #endregion


        #region [Récupérer]

        public override List<Case> RecupererListeCasesDisponibles()
        {
            List<Case> lListeCasesDisponibles = [];
            List<List<int>> lListeCoordonneesACheck = [[Ligne - 1, Colonne]];
            if (NbDeplacement < 1)
            {
                lListeCoordonneesACheck.Add([Ligne - 2, Colonne]);
            }

            foreach (var lCoordonee in lListeCoordonneesACheck)
            {
                Case? lCaseACheck = PlateauHelper.RecupererCase(Moteur.Grille, lCoordonee);

                if (lCaseACheck == null)
                {
                    continue;
                }

                if (lCaseACheck.Piece != null)
                {
                    if (lCaseACheck.Piece.Team != Moteur.TeamJoueur)
                    {
                        lListeCasesDisponibles.Add(lCaseACheck);
                    }
                }
                else
                {
                    lListeCasesDisponibles.Add(lCaseACheck);
                }
            }

            return lListeCasesDisponibles;
        }

        #endregion
    }
}
