using Echecs.Controls;
using Echecs.Enums;
using Echecs.Helper;

namespace Echecs.Pieces
{
    public partial class Roi : Piece
    {
        #region [Propriétés]

        private readonly Moteur Moteur = Moteur.Instance;

        #endregion


        #region [Constructeurs - Initialisation]

        public Roi() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Roi(EnumJoueur pJoueur, List<int> pPosition) : base(pJoueur, pPosition)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Roi" + base.Couleur + ".png";
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
            for (int lLigne = -1; lLigne < 2; lLigne++)
            {
                for (int lColonne = -1; lColonne < 2; lColonne++)
                {
                    if (lLigne == 0 && lColonne == 0)
                    {
                        continue;
                    }

                    lListeCoordonneesACheck.Add([Ligne + lLigne, Colonne + lColonne]);
                }
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
