using System;
using System.Linq.Expressions;
using Gtk;
using System.Reflection;
using Pony.Validation;

namespace Pony.GtkSharp
{
	public class ViewDialog<T> : Gtk.Dialog where T : class, new()
	{
		protected ViewResult _result;

		private readonly IPonyApplication _ponyApplication;

		public T Model { get; private set; }

		protected delegate void BindingEvent();

		protected event BindingEvent ModelChanged;

		public ViewDialog (IPonyApplication ponyApplication)
		{
			_result = ViewResult.None;
			_ponyApplication = ponyApplication;
            DeleteEvent += (o, args) => { if (Model == null) Model = new T (); };
            DestroyEvent += (o, args) => { if (Model == null) Model = new T (); };
            Response += (o, args) => { if (Model == null) Model = new T (); };
		}

		public void SetModel(T model)
		{
			Model = model;
			if (ModelChanged != null) ModelChanged();
		}

		public new void Show()
		{
            //This is required for instantiation of ViewDialog without showing it.
		}

        protected void Bind<TBind, TControl, TView>(
            Expression<Func<T, TBind>> modelPropertyExpr,
            Expression<Func<TView, TControl>> formPropertyExpr)
            where TView : ViewDialog<T>
            where TControl : Entry
        {
            var modelMember = (MemberExpression)modelPropertyExpr.Body;
            var modelProperty = (PropertyInfo)modelMember.Member;

            var formMember = (MemberExpression)formPropertyExpr.Body;
            var formProperty = (FieldInfo)formMember.Member;
            var control = (Entry)formProperty.GetValue(this);

            //var propertyValidationAttributes =
                //modelProperty.GetCustomAttributes<PropertyValidationAttribute>(true).ToList();

            ModelChanged += () => control.Text = _ponyApplication.GetSerializer<TBind>().Serialize((TBind)modelProperty.GetValue(Model));

            Response += (o, args) =>
            {
                if (args.ResponseId == ResponseType.Ok || args.ResponseId == ResponseType.Accept)
                {
                    modelProperty.SetValue(Model, _ponyApplication.GetSerializer<TBind>().Deserialize(control.Text));
                }
            };
        }
	}
}

