
// This file has been generated by the GUI designer. Do not modify.
namespace Pony.GtkSharp.Demo
{
	public partial class ItemEd
	{
		private global::Gtk.Fixed fixed1;
		
		private global::Gtk.Entry NameEditor;
		
		private global::Gtk.Entry AmountEditor;
		
		private global::Gtk.Entry CommentEditor;
		
		private global::Gtk.CheckButton IsActiveBox;
		
		private global::Gtk.Button OkBtn;
		
		private global::Gtk.Button CancelBtn;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Pony.GtkSharp.Demo.ItemEd
			this.Name = "Pony.GtkSharp.Demo.ItemEd";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child Pony.GtkSharp.Demo.ItemEd.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.NameEditor = new global::Gtk.Entry ();
			this.NameEditor.CanFocus = true;
			this.NameEditor.Name = "NameEditor";
			this.NameEditor.IsEditable = true;
			this.NameEditor.InvisibleChar = '●';
			this.fixed1.Add (this.NameEditor);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.NameEditor]));
			w2.X = 2;
			w2.Y = 5;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.AmountEditor = new global::Gtk.Entry ();
			this.AmountEditor.CanFocus = true;
			this.AmountEditor.Name = "AmountEditor";
			this.AmountEditor.IsEditable = true;
			this.AmountEditor.InvisibleChar = '●';
			this.fixed1.Add (this.AmountEditor);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.AmountEditor]));
			w3.X = 2;
			w3.Y = 35;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.CommentEditor = new global::Gtk.Entry ();
			this.CommentEditor.CanFocus = true;
			this.CommentEditor.Name = "CommentEditor";
			this.CommentEditor.IsEditable = true;
			this.CommentEditor.InvisibleChar = '●';
			this.fixed1.Add (this.CommentEditor);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.CommentEditor]));
			w4.X = 2;
			w4.Y = 65;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.IsActiveBox = new global::Gtk.CheckButton ();
			this.IsActiveBox.CanFocus = true;
			this.IsActiveBox.Name = "IsActiveBox";
			this.IsActiveBox.Label = global::Mono.Unix.Catalog.GetString ("IsActive");
			this.IsActiveBox.DrawIndicator = true;
			this.IsActiveBox.UseUnderline = true;
			this.fixed1.Add (this.IsActiveBox);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.IsActiveBox]));
			w5.X = 3;
			w5.Y = 98;
			w1.Add (this.fixed1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(w1 [this.fixed1]));
			w6.Position = 0;
			// Internal child Pony.GtkSharp.Demo.ItemEd.ActionArea
			global::Gtk.HButtonBox w7 = this.ActionArea;
			w7.Name = "dialog1_ActionArea";
			w7.Spacing = 10;
			w7.BorderWidth = ((uint)(5));
			w7.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.OkBtn = new global::Gtk.Button ();
			this.OkBtn.CanFocus = true;
			this.OkBtn.Name = "OkBtn";
			this.OkBtn.UseStock = true;
			this.OkBtn.UseUnderline = true;
			this.OkBtn.Label = "gtk-ok";
			this.AddActionWidget (this.OkBtn, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w7 [this.OkBtn]));
			w8.Expand = false;
			w8.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.CancelBtn = new global::Gtk.Button ();
			this.CancelBtn.CanFocus = true;
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.UseStock = true;
			this.CancelBtn.UseUnderline = true;
			this.CancelBtn.Label = "gtk-cancel";
			this.AddActionWidget (this.CancelBtn, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w7 [this.CancelBtn]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
