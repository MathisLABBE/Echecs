using Echecs.Controls;
using Echecs.Enums;
using Echecs.Helper;

namespace Echecs.Pieces
{
    public partial class Cavalier : Piece
    {
        #region [Propriétés]

        private readonly Moteur Moteur = Moteur.Instance;

        #endregion


        #region [Constructeurs - Initialisation]

        public Cavalier() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Cavalier(EnumJoueur pJoueur, List<int> pPosition) : base(pJoueur, pPosition)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Cavalier" + base.Couleur + ".png";
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
            List<List<int>> lListeCoordonneesACheck = [];

            lListeCoordonneesACheck.Add([Ligne - 2, Colonne - 1]);
            lListeCoordonneesACheck.Add([Ligne - 2, Colonne + 1]);

            lListeCoordonneesACheck.Add([Ligne + 2, Colonne - 1]);
            lListeCoordonneesACheck.Add([Ligne + 2, Colonne + 1]);

            lListeCoordonneesACheck.Add([Ligne - 1, Colonne - 2]);
            lListeCoordonneesACheck.Add([Ligne + 1, Colonne - 2]);

            lListeCoordonneesACheck.Add([Ligne - 1, Colonne + 2]);
            lListeCoordonneesACheck.Add([Ligne + 1, Colonne + 2]);

            List<Case> lListeCasesDisponibleFiltree = [];

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
                        lListeCasesDisponibleFiltree.Add(lCaseACheck);
                    }
                }
                else
                {
                    lListeCasesDisponibleFiltree.Add(lCaseACheck);
                }
            }

            return lListeCasesDisponibleFiltree;
        }

        #endregion
    }
}
