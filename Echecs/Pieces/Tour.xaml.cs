using Echecs.Controls;
using Echecs.Enums;
using Echecs.Helper;

namespace Echecs.Pieces
{
    public partial class Tour : Piece
    {
        #region [Propriétés]

        private readonly Moteur Moteur = Moteur.Instance;

        #endregion


        #region [Constructeurs - Initialisation]

        public Tour() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Tour(EnumJoueur pJoueur, List<int> pPosition) : base(pJoueur, pPosition)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Tour" + base.Couleur + ".png";
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
            List<Case?> lListeCasesDisponibles = [];

            // Récupère les cases à checks
            Case? lCaseVoisine;
            int lPositionCaseSimulation = 0;

            do
            {
                lCaseVoisine = PlateauHelper.RecupererCaseGauche(Moteur.Grille, Ligne, Colonne - lPositionCaseSimulation);
                lListeCasesDisponibles.Add(lCaseVoisine);
                lPositionCaseSimulation++;
            }
            while (lCaseVoisine != null && lCaseVoisine.Piece == null);
            lPositionCaseSimulation = 0;

            do
            {
                lCaseVoisine = PlateauHelper.RecupererCaseDroite(Moteur.Grille, Ligne, Colonne + lPositionCaseSimulation);
                lListeCasesDisponibles.Add(lCaseVoisine);
                lPositionCaseSimulation++;
            }
            while (lCaseVoisine != null && lCaseVoisine.Piece == null);
            lPositionCaseSimulation = 0;

            do
            {
                lCaseVoisine = PlateauHelper.RecupererCaseHaut(Moteur.Grille, Ligne - lPositionCaseSimulation, Colonne);
                lListeCasesDisponibles.Add(lCaseVoisine);
                lPositionCaseSimulation++;
            }
            while (lCaseVoisine != null && lCaseVoisine.Piece == null);
            lPositionCaseSimulation = 0;

            do
            {
                lCaseVoisine = PlateauHelper.RecupererCaseBas(Moteur.Grille, Ligne + lPositionCaseSimulation, Colonne);
                lListeCasesDisponibles.Add(lCaseVoisine);
                lPositionCaseSimulation++;
            }
            while (lCaseVoisine != null && lCaseVoisine.Piece == null);

            List<Case> lListeCasesDisponibleFiltree = [];

            foreach (var lCaseDispo in lListeCasesDisponibles)
            {
                if (lCaseDispo != null)
                {
                    if (lCaseDispo.Piece != null)
                    {
                        if (lCaseDispo.Piece.Team == Moteur.TeamJoueur)
                        {
                            continue;
                        }
                    }
                    lListeCasesDisponibleFiltree.Add(lCaseDispo);
                }
            }
            return lListeCasesDisponibleFiltree;
        }

        #endregion
    }
}
