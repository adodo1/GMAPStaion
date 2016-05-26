using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GMAPStaion
{
    [Serializable]
    public class GMapMarkerWP : GMarkerGoogle
    {
        const float rad2deg = (float)(180 / Math.PI);
        const float deg2rad = (float)(1.0 / rad2deg);

        string wpno = "";
        public bool selected = false;

        public GMapMarkerWP(PointLatLng point, string wpno)
            : base(point, GMarkerGoogleType.green)
        {
            this.wpno = wpno;
        }

        public override void OnRender(Graphics g)
        {
            if (selected) {
                g.FillEllipse(Brushes.Red, new Rectangle(this.LocalPosition, this.Size));
                g.DrawArc(Pens.Red, new Rectangle(this.LocalPosition, this.Size), 0, 360);
            }

            base.OnRender(g);
            var midw = LocalPosition.X + 10;
            var midh = LocalPosition.Y + 3;
            var txtsize = TextRenderer.MeasureText(wpno, SystemFonts.DefaultFont);
            if (txtsize.Width > 15)
                midw -= 4;
            g.DrawString(wpno, SystemFonts.DefaultFont, Brushes.Black, new PointF(midw, midh));
        }
    }
}
