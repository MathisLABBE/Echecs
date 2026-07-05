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
            List<List<int>> lListeCoordonneesACheck = [];
            List<List<int>> lListeCoordonneesACheckDiagonale = [];

            // Récupère les coordonées à check
            if (Team == Moteur.TeamJoueur)
            {
                lListeCoordonneesACheck.Add([Ligne - 1, Colonne]);
                if (NbDeplacement < 1)
                {
                    lListeCoordonneesACheck.Add([Ligne - 2, Colonne]);
                }

                lListeCoordonneesACheckDiagonale.Add([Ligne - 1, Colonne - 1]);
                lListeCoordonneesACheckDiagonale.Add([Ligne - 1, Colonne + 1]);
            }
            else
            {
                lListeCoordonneesACheck.Add([Ligne + 1, Colonne]);
                if (NbDeplacement < 1)
                {
                    lListeCoordonneesACheck.Add([Ligne + 2, Colonne]);
                }

                lListeCoordonneesACheckDiagonale.Add([Ligne + 1, Colonne - 1]);
                lListeCoordonneesACheckDiagonale.Add([Ligne + 1, Colonne + 1]);
            }

            // Cases devant
            foreach (var lCoordonee in lListeCoordonneesACheck)
            {
                Case? lCaseACheck = PlateauHelper.RecupererCase(Moteur.Grille, lCoordonee);

                if (lCaseACheck == null)
                {
                    continue;
                }

                if (lCaseACheck.Piece == null)
                {
                    lListeCasesDisponibles.Add(lCaseACheck);
                }
            }

            // Cases sur le côté
            foreach (var lCoordonee in lListeCoordonneesACheckDiagonale)
            {
                Case? lCaseACheck = PlateauHelper.RecupererCase(Moteur.Grille, lCoordonee);

                if (lCaseACheck == null)
                {
                    continue;
                }

                if (lCaseACheck.Piece != null)
                {
                    if (lCaseACheck.Piece.Team == Moteur.JoueurAdverse)
                    {
                        lListeCasesDisponibles.Add(lCaseACheck);
                    }
                }
            }

            return lListeCasesDisponibles;
        }

        #endregion


        #region [Changer Pion]

        public bool EstSurDerniereLigne()
        {
            int lLigneDeFond;

            if (Team == Moteur.TeamJoueur)
            {
                lLigneDeFond = 0;
            }
            else
            {
                lLigneDeFond = 7;
            }

            if (Ligne == lLigneDeFond)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
