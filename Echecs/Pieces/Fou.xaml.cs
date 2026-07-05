using Echecs.Controls;
using Echecs.Enums;
using Echecs.Helper;

namespace Echecs.Pieces
{
    public partial class Fou : Piece
    {
        #region [Propriétés]

        private readonly Moteur Moteur = Moteur.Instance;

        #endregion


        #region [Constructeurs - Initialisation]

        public Fou() : base()
        {
            Initialisation();

            InitializeComponent();
        }

        public Fou(EnumJoueur pJoueur, List<int> pPosition) : base(pJoueur, pPosition)
        {
            Initialisation();

            InitializeComponent();
        }

        private void Initialisation()
        {
            base.CheminImage += "Fou" + base.Couleur + ".png";
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
                lCaseVoisine = PlateauHelper.RecupererCaseHautGauche(Moteur.Grille, Ligne - lPositionCaseSimulation, Colonne - lPositionCaseSimulation);
                lListeCasesDisponibles.Add(lCaseVoisine);
                lPositionCaseSimulation++;
            }
            while (lCaseVoisine != null && lCaseVoisine.Piece == null);
            lPositionCaseSimulation = 0;

            do
            {
                lCaseVoisine = PlateauHelper.RecupererCaseHautDroite(Moteur.Grille, Ligne - lPositionCaseSimulation, Colonne + lPositionCaseSimulation);
                lListeCasesDisponibles.Add(lCaseVoisine);
                lPositionCaseSimulation++;
            }
            while (lCaseVoisine != null && lCaseVoisine.Piece == null);
            lPositionCaseSimulation = 0;

            do
            {
                lCaseVoisine = PlateauHelper.RecupererCaseBasGauche(Moteur.Grille, Ligne + lPositionCaseSimulation, Colonne - lPositionCaseSimulation);
                lListeCasesDisponibles.Add(lCaseVoisine);
                lPositionCaseSimulation++;
            }
            while (lCaseVoisine != null && lCaseVoisine.Piece == null);
            lPositionCaseSimulation = 0;

            do
            {
                lCaseVoisine = PlateauHelper.RecupererCaseBasDroite(Moteur.Grille, Ligne + lPositionCaseSimulation, Colonne + lPositionCaseSimulation);
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
                        if (lCaseDispo.Piece.Team == Moteur.JoueurActuel)
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
