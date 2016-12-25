using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TPMapEditor
{
	class GreenStripRenderer : ToolStripProfessionalRenderer
	{
		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);

			LinearGradientBrush linGrBrush = new LinearGradientBrush(Point.Empty, new Point(0, e.Item.Size.Height), Color.Empty, Color.Empty);

			ColorBlend cblend = new ColorBlend(3);
			cblend.Colors = new Color[3] { e.Item.Selected ? Color.FromArgb(255, 102, 230, 102) : Color.FromArgb(255, 205, 242, 182),
											   e.Item.Selected ? Color.FromArgb(255, 102, 255, 102) : Color.FromArgb(255, 205, 248, 182),
											   e.Item.Selected ? Color.FromArgb(255, 102, 230, 102) : Color.FromArgb(255, 205, 242, 182) };
			cblend.Positions = new float[3] { 0f, 0.5f, 1f };
			linGrBrush.InterpolationColors = cblend;

			e.Graphics.FillRectangle(linGrBrush, rc);
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			Rectangle rc = new Rectangle(Point.Empty, e.AffectedBounds.Size);

			LinearGradientBrush linGrBrush = new LinearGradientBrush(Point.Empty, new Point(0, rc.Height), Color.Empty, Color.Empty);

			ColorBlend cblend = new ColorBlend(3);
			cblend.Colors = new Color[3] { Color.FromArgb(255, 205, 242, 182),
											   Color.FromArgb(255, 205, 248, 182),
											   Color.FromArgb(255, 205, 242, 182) };
			cblend.Positions = new float[3] { 0f, 0.5f, 1f };
			linGrBrush.InterpolationColors = cblend;

			e.Graphics.FillRectangle(linGrBrush, rc);
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);

			LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 0), new Point(e.Item.Size.Width, 0), Color.Empty, Color.Empty);

			ColorBlend cblend = new ColorBlend(3);
			cblend.Colors = new Color[3] {Color.FromArgb(255, 205, 242, 182),
											  Color.FromArgb(235, 0, 0, 0),
											  Color.FromArgb(255, 205, 242, 182) };
			cblend.Positions = new float[3] { 0.0f, 0.5f, 1.0f };
			linGrBrush.InterpolationColors = cblend;

			e.Graphics.DrawLine(new Pen(linGrBrush), new Point(0, e.Item.Height / 2), new Point(e.Item.Width, e.Item.Height / 2));

		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			// Do NOT delete this function.
		}
	}
}
