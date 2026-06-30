using Echecs.Controls;
using System.Windows.Media;

namespace Echecs.Helper
{
    public static class PlateauHelper
    {
        public static Brush RecupererCouleurCase(int pLigne, int pColonne)
        {
            if ((pLigne + pColonne) % 2 == 0)
            {
                return Brushes.White;
            }
            else
            {
                return Brushes.DarkGreen;
            }
        }

        public static void CacherCasesDisponibles(List<List<Case>> pGrille)
        {
            foreach (var lLigne in pGrille)
            {
                foreach (var lCase in lLigne)
                {
                    lCase.CouleurSurlignage = Brushes.Transparent;
                }
            }
        }
    }
}
